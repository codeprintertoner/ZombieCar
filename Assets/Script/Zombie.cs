using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    
    [SerializeField]
    Rigidbody zrb;
    Animator zani;
    [SerializeField]
    private PlayerMove player;
    [SerializeField]
    private CamShake camShake;
    [SerializeField]
    private GameObject Particle;
    [SerializeField]
    private GameObject HitParticle;
    private ItemSpawner itemspawner;
    public AudioSource audioSource;
    


    
    private ZombieDieColor zombieDieColor; 

       public float slowFactor = 0.5f;

       


    bool isdie = false;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        zrb = GetComponent<Rigidbody>();
        zani = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMove>();
        camShake = FindObjectOfType<CamShake>();
        itemspawner = FindObjectOfType<ItemSpawner>();
        zombieDieColor = GetComponentInChildren<ZombieDieColor>();
       
    }
    //���� �װ� ������ƮǮ���� �ٽ� ���ö� ���¸� �ʱ�ȭ ����
    void OnEnable()
    {
        //������ Ǯ����� �ప�� �ٽ� ������
        zrb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        //����ó���߶� bool���� �ʱ�ȭ����
        isdie = false;
               
        //���� �׾����� ���������� ǥ�õȰ� �ٽ� ������ ����� �ٲ���
        zombieDieColor.skinnedMeshRenderer.materials[0].color = Color.white;
        zombieDieColor.skinnedMeshRenderer.materials[1].color = Color.white;
        //���� ��Ӱ�ü�� Hit��ƼŬ�� ����� ���·� �������
        HitParticle.SetActive(false);
        
        //������ �⺻ ������ MOVE�� �ڷ�ƾ ����.
        nextState(STATE.MOVE);

    }

    private void Update()
    {   
        
        BoundaryCheck();
    }
    // �÷��̾�� ���� �����Ÿ� �̻� ���������� üũ���ִ� �Լ�
    void BoundaryCheck()
    {
        if (player.transform.position.x - transform.position.x > 25) // �÷��̾��� x��ǥ�� ���� ��ǥ�� ������ ���� ���ݺ��� Ŭ�� // ���������� ����
        {
            SetZombie(2);
        }
        if (player.transform.position.x - transform.position.x < -25) // �������� ����
        {
            SetZombie(0);

        }
        if (player.transform.position.z - transform.position.z > 25) // ���� ����
        {
            SetZombie(1);

        }
        if (player.transform.position.z - transform.position.z < -25) // �Ʒ��� ����
        {
            SetZombie(3);
        }
    }

    //  BoundaryCheck�� �÷��̾��� ����� �Ÿ��� Ȯ���Ͽ� ���� ��ġ�� ��ȯ�Ѵ�.
    void SetZombie(int dir)
    {
        switch (dir)
        {

            case 0:
                { transform.position += Vector3.left * 50; }
                break;
            case 1:
                { transform.position += Vector3.forward * 50; }
                break;
            case 2:
                { transform.position += Vector3.right * 50; }
                break;
            case 3:
                { transform.position += Vector3.back * 50; }
                break;

        }
    }

    



    //enum�� ����� �ڷ�ƾ.
    Coroutine prevCoroutine = null;
    public enum STATE
    {
        NONE,   // �ƹ��͵� �ƴ� ����
        MOVE,
        DEATH,
        
    }
    public STATE curState = STATE.NONE;
    

   
    // �ڷ�ƾ�� STATE�� ����ɶ� �ڷ�ƾ�� ����Ǵ� �Լ�
    void nextState(STATE newState) 
    {
        if(newState == curState) // �������¶� ������ ����
            return;
        if (prevCoroutine != null)
            StopCoroutine(prevCoroutine);

        //���ο���·� ��ȯ
        curState = newState;
        prevCoroutine = StartCoroutine(newState.ToString());

    }

    
    IEnumerator MOVE()
    {
        
        while (!isdie)
        {
            
            //����� �÷��̾� �������� ������ �����Ѵ�.
            Vector3 GO = (transform.forward * Time.deltaTime);
            zrb.MovePosition(zrb.position + GO);
            //���� �÷��̾� �������� �̵��Ѵ�.
            transform.LookAt(player.transform);
            //�÷��̾� �ִϸ��̼� ���� �۵�.
            zani.SetFloat("MoveSpeed", Vector3.forward.z);


            yield return null;

        }
    }
    
    IEnumerator DEATH()
    {
        //���� �׾����� ����� ����
        audioSource.Play();

        
        //������ ��ƼŬ ����/ ������Ʈ Ǯ���� ������
        Vector3 transformY = new Vector3(0,0.5f,0);
        Particle = ParticlePool.Inst.CreateParticle(transform.position + transformY);
        //��ƼŬ�� ��Ȱ��ȭ �ɶ� setparent�� �־���
        Particle.transform.SetParent(transform);
        
        //��ƼŬ ��Ȱ��ȭ�� 0.5f�ʵڿ� ����
        StartCoroutine(HideParticle());
        //Hit��ƼŬ�� Ȱ��ȭ�մϴ�.
        HitParticle.SetActive(true);
        //���� Dead �ִϸ��̼� ���
        zani.SetTrigger("Dead");
        //������ƮǮ ������ ����� ��ƼŬ �ֱ�
        StartCoroutine(HideObj());
        
        isdie = true;
        // ������ٵ� ����� Ǯ��
        zrb.constraints = RigidbodyConstraints.None;

       
        //zrb.useGravity = false;

        //���ھ� ���� UI�Ŵ����� ������
        UIManager.Inst.Score(100);
        // ī�޶� ����
        camShake.camShake();
        // ���� ������ ������ �ٲ���
        zombieDieColor.Materia();
        // ���ο���
        SlowTime();
        // ���ο������� ������ Ÿ�ӽ������� ������� ����;
        StartCoroutine(JustTime());


        yield return null;
    }
    void SlowTime()
    {
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = 0.02f;
    }

    IEnumerator HideParticle()
    {

        yield return new WaitForSecondsRealtime(0.5f);
        
        
        itemspawner.Spawn(transform.position);
        
    }   

    IEnumerator HideObj()
    {

        yield return new WaitForSeconds(2f);
        
        ObjectPool.Instance.DestroyZombie(this);
        ParticlePool.Inst.DestroyParticle(Particle);
    }

    IEnumerator JustTime()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        if(Time.timeScale <= 1f)
        {
            Time.timeScale = 1f;
        }
    }
    

    void OnCollisionEnter(Collision collision)
    {
        //�÷��̾�� �浹������
        if (collision.gameObject.tag == "Player" )
        {
         // ����ִ� ���� �ӵ� 2�� �浹������ �ӵ� -1
            if (player.speed > 2 && !isdie)
            {
                player.speed -= 1f;
            }
         // ����ִ� ���� �ӵ�5�� �浹������ ���� ����
            if (player.speed > 5 && !isdie)
            {
            nextState(STATE.DEATH);

            }
            

        }

    }
}
