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
        
        // 시간이 지날수록 가속도 올리기 / 무브스피드가 10일때 가속하지않음.
        if (speed < 8)
        {
        speed += Time.deltaTime;
        }

        Vector3 foward = transform.forward * MoveSpeed * speed;

        prb.MovePosition(foward);

        //상대적으로 회전할 수치 계산
        float turn = inputRotate * rotateSpeed * Time.deltaTime;
        //리지드바디를 이용해 게임 오브젝트 회전 변경
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
