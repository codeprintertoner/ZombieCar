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

    float DieTime; 

    bool isdie = false;
    
    void Awake()
    {

        zrb = GetComponent<Rigidbody>();
        zani = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMove>();

    }

    void OnEnable()
    {
     


        zrb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        isdie = false;
        zrb.useGravity = true;
        nextState(STATE.MOVE);

    }

    // Update is called once per frame
    void Update()
    {
        DieTime += Time.deltaTime;
        
    }

 
   

    Coroutine prevCoroutine = null;
    public enum STATE
    {
        NONE,   // �ƹ��͵� �ƴ� ����
        MOVE,
        DEATH,
        
    }
    public STATE curState = STATE.NONE;

    
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
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        StartCoroutine(HideObj());
        isdie = true;

        zrb.constraints = RigidbodyConstraints.None;
        zrb.useGravity = false;

        yield return null;
    }

    IEnumerator HideObj()
    {

        yield return new WaitForSeconds(3f);
        ObjectPool.Instance.DestroyZombie(this);
        
    }

    void OnCollisionEnter(Collision collision)
    {


     

        if (collision.gameObject.tag == "Player" && player.speed > 5)
        {

            nextState(STATE.DEATH);
            //zombie.Die();

            //Vector3 force = (collision.transform.position - transform.position).normalized;
            //zombie.GetComponent<Rigidbody>().AddForce(force * 100f);

        }

    }
}
