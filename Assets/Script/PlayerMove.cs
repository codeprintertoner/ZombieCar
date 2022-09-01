using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float MoveSpeed = 5f;
    float rotateSpeed = 180f;
    private Rigidbody prb;
    float speed;

    [SerializeField]
    private Zombie zombie;

    public ZombieSpawner zombieSpawner;

    


    public float inputRotate { get; private set; }


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

        Vector3 foward = transform.forward * MoveSpeed * speed;

        prb.MovePosition(foward);

        //��������� ȸ���� ��ġ ���
        float turn = inputRotate * rotateSpeed * Time.deltaTime;
        //������ٵ� �̿��� ���� ������Ʈ ȸ�� ����
         prb.rotation *= Quaternion.Euler(0f, turn, 0f);
    
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie" && speed > 4)
        {

            zombie = collision.gameObject.GetComponent<Zombie>();
            zombie.Die();
            speed -= 2;
            Debug.Log(speed);


    }
}



}
