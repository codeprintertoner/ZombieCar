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
    private ItemSpawner itemspawner;



    private ZombieDieColor zombieDieColor;

       public float slowFactor = 0.5f;

       


    bool isdie = false;
    
    void Awake()
    {

        zrb = GetComponent<Rigidbody>();
        zani = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMove>();
        camShake = FindObjectOfType<CamShake>();
        itemspawner = FindObjectOfType<ItemSpawner>();
        zombieDieColor = GetComponentInChildren<ZombieDieColor>();
    }

    void OnEnable()
    {
     


        zrb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        isdie = false;
        zrb.useGravity = true;
        zombieDieColor.skinnedMeshRenderer.materials[0].color = Color.white;
        zombieDieColor.skinnedMeshRenderer.materials[1].color = Color.white;

        nextState(STATE.MOVE);

    }

    private void Update()
    {
        BoundaryCheck();
    }
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





    Coroutine prevCoroutine = null;
    public enum STATE
    {
        NONE,   // �ƹ��͵� �ƴ� ����
        MOVE,
        DEATH,
        
    }
    public STATE curState = STATE.NONE;

    void SlowTime()
    {
        Time.timeScale = slowFactor;
        Time.fixedDeltaTime = 0.02f;

    }

   

    void nextState(STATE newState) //
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
            transform.LookAt(player.transform);
            //�÷��̾� �ִϸ��̼� ���� �۵�
            zani.SetFloat("MoveSpeed", Vector3.forward.z);
            yield return null;

        }
    }
    
    IEnumerator DEATH()
    {

        Vector3 transformY = new Vector3(0,0.5f,0);
        Particle = ParticlePool.Inst.CreateParticle(transform.position + transformY);
        Particle.transform.SetParent(transform);

        StartCoroutine(HideParticle());

        zani.SetTrigger("Dead");


        //gameObject.GetComponent<BoxCollider>().isTrigger = true;
        StartCoroutine(HideObj());
        

        isdie = true;

        zrb.constraints = RigidbodyConstraints.None;

       
        //zrb.useGravity = false;

        UIManager.Inst.Score(100);

        camShake.camShake();

        zombieDieColor.Materia();

        SlowTime();

        StartCoroutine(JustTime());

        

        



        yield return null;
    }


    IEnumerator HideParticle()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        ParticleManager.Inst.offParticle();
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

        if (collision.gameObject.tag == "Player" )
        {

            if (player.speed > 2 && !isdie)
            {
                player.speed -= 1f;
            }

            if (player.speed > 5 && !isdie)
            {
            nextState(STATE.DEATH);

            }
            

        }

    }
}
