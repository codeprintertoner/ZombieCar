using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    float rotateSpeed = 180f;
    [SerializeField]
    private Rigidbody prb;
    
    public float speed { get; set; }


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

        
        // 시간이 지날수록 가속도 올리기 / 무브스피드가 10일때 가속하지않음.
        if (speed < 10)
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

        //상대적으로 회전할 수치 계산
        float turn = inputRotate * rotateSpeed * Time.deltaTime;
        //리지드바디를 이용해 게임 오브젝트 회전 변경
        prb.rotation *= Quaternion.Euler(0f, turn, 0f);


    }

    
}
