using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody zrb;
    Animator zani;
    [SerializeField]
    private PlayerMove player;
    [SerializeField]
    private CamShake camShake;

    private ZombieDieColor zombieDieColor;

       public float slowFactor = 0.5f;

       


    bool isdie = false;
    
    void Awake()
    {

        zrb = GetComponent<Rigidbody>();
        zani = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMove>();
        camShake = FindObjectOfType<CamShake>();
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

    // Update is called once per frame
    void Update()
    {

        
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

    IEnumerator HideObj()
    {

        yield return new WaitForSeconds(2f);
        ObjectPool.Instance.DestroyZombie(this);
        
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


     

        if (collision.gameObject.tag == "Player"  )
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
