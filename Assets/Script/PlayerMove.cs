using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float MoveSpeed = 100f;
    float rotateSpeed = 180f;
    [SerializeField]
    private Rigidbody prb;
    float speed;

    [SerializeField]
    private Zombie zombie;

    public ZombieSpawner zombieSpawner;

    


    public float inputRotate { get; private set; }
    public float inputRotate2 { get; private set; }


    void Start()
    {
        prb = GetComponent<Rigidbody>();
        zombie = FindObjectOfType<Zombie>();

    }

    // Update is called once per frame
    void Update()
    {

      


    }

    private void FixedUpdate()
    {
        Move();   
    }
    
    private void Move()
    {
        inputRotate = Input.GetAxis("Horizontal");
        

        // �ð��� �������� ���ӵ� �ø��� / ���꽺�ǵ尡 10�϶� ������������.
        if (speed < 8)
        {
        speed += Time.deltaTime;
        }

        Vector3 foward = transform.forward * speed * Time.deltaTime;
        prb.MovePosition(prb.position + foward);

        

        //Vector3 lastpos = transform.position;
        //float dist = (lastpos - transform.position).magnitude;
        //float timer = 0f;
        //timer += Time.deltaTime;
        //float a = dist / timer ;
        //timer = 0f;
        //lastpos = transform.position;

        //��������� ȸ���� ��ġ ���
        float turn = inputRotate * rotateSpeed * Time.deltaTime;
        //������ٵ� �̿��� ���� ������Ʈ ȸ�� ����
         prb.rotation *= Quaternion.Euler(0f, turn, 0f);
    
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("����");
        if (speed > 2)
        {
        speed -= 0.5f;
        }
        Debug.Log(speed);
        if (collision.gameObject.tag == "Zombie" && speed > 5)
        {

            zombie = collision.gameObject.GetComponent<Zombie>();
            zombie.Die();
            
            

            //Vector3 force = (collision.transform.position - transform.position).normalized;
            //zombie.GetComponent<Rigidbody>().AddForce(force * 100f);


    }

    }

    void OnTriggerEnter(Collider other)
        {
         
        }
    

}
