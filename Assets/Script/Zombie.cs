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

    void Start()
    {
        zrb = GetComponent<Rigidbody>();
        zani = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DieTime += Time.deltaTime;
        Move();
    }

    private void Move()
    {
        if (!isdie)
        {
        //����� �÷��̾� �������� ������ �����Ѵ�.
        Vector3 GO = (transform.forward * Time.deltaTime)/2;
        zrb.MovePosition(zrb.position + GO);
        transform.LookAt(player.transform);
        //�÷��̾� �ִϸ��̼� ���� �۵�
        zani.SetFloat("MoveSpeed", Vector3.forward.z);
            
        }

        
    }
    public void Die()
    {
        zani.SetTrigger("Dead");
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        StartCoroutine(HideObj());
        isdie = true;

        


    }

    IEnumerator HideObj()
    {

        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
