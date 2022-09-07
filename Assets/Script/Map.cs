using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //�� �迭 ���� 
    [SerializeField] private GameObject[] LandArray;
    //�÷��̾� // �÷��̾� ��ǥ���� �޾ƿ������ؼ� �����´� 
    [SerializeField] private Transform player;
    //Ÿ�� ũ�� 
    readonly float LandSize = 50f;

  

    
    private void Update()
    {
        // ���� Ÿ�� ��ġ�� ������ üũ
        BoundaryCheck();
    }

    //Ÿ���� ���� �ű��� üũ
    void BoundaryCheck()
    {   // �÷��̾��� x��ǥ�� ���� ��ǥ�� ������ ���� ���ݺ��� Ŭ�� // ���������� ����
        if (player.position.x - transform.position.x > LandSize / 2 ) 
        {
            MoveLand(2);
        }// �������� ����
        if (player.position.x - transform.position.x < -LandSize / 2) 
        {
            MoveLand(0);

        } // ���� ����
        if (player.position.z - transform.position.z > LandSize / 2)
        {
            MoveLand(1);

        }// �Ʒ��� ����
        if (player.position.z - transform.position.z < -LandSize / 2) 
        {
            MoveLand(3);
        }
    }
    
    void MoveLand (int dir)
    {
        //���� �迭�� ����. LandArray��  ���ο�迭, _LandArray�� ���� �迭�� ���Ѵ�.
        GameObject[] _LandArray = new GameObject[9];
        System.Array.Copy(LandArray, _LandArray, 9);

        switch(dir)
        {
            case 0:
                {
                    transform.position += Vector3.left * LandSize; // 9������ǥ������ִ� ������� ��ǥ�� 50��ŭ�̵���


                    _LandArray[0] = LandArray[2];
                    _LandArray[1] = LandArray[0];
                    _LandArray[2] = LandArray[1];
                    _LandArray[3] = LandArray[5];
                    _LandArray[4] = LandArray[3];
                    _LandArray[5] = LandArray[4];
                    _LandArray[6] = LandArray[8];
                    _LandArray[7] = LandArray[6];
                    _LandArray[8] = LandArray[7];

                    LandArray[2].transform.position += Vector3.left * 150;
                    LandArray[5].transform.position += Vector3.left * 150;
                    LandArray[8].transform.position += Vector3.left * 150;

                    System.Array.Copy(_LandArray, LandArray, 9);


                }
                break;
            case 1:
                {
                    transform.position += Vector3.forward * LandSize;

                    _LandArray[0] = LandArray[6];
                    _LandArray[1] = LandArray[7];
                    _LandArray[2] = LandArray[8];
                    _LandArray[3] = LandArray[0];
                    _LandArray[4] = LandArray[1];
                    _LandArray[5] = LandArray[2];
                    _LandArray[6] = LandArray[3];
                    _LandArray[7] = LandArray[4];
                    _LandArray[8] = LandArray[5];

                    LandArray[6].transform.position += Vector3.forward * 150;
                    LandArray[7].transform.position += Vector3.forward * 150;
                    LandArray[8].transform.position += Vector3.forward * 150;

                    System.Array.Copy(_LandArray, LandArray, 9);
                }
                break;
            case 2:
                {
                    transform.position += Vector3.right * LandSize;

                    _LandArray[0] = LandArray[1];
                    _LandArray[1] = LandArray[2];
                    _LandArray[2] = LandArray[0];
                    _LandArray[3] = LandArray[4];
                    _LandArray[4] = LandArray[5];
                    _LandArray[5] = LandArray[3];
                    _LandArray[6] = LandArray[7];
                    _LandArray[7] = LandArray[8];
                    _LandArray[8] = LandArray[6];

                    LandArray[0].transform.position += Vector3.right * 150;
                    LandArray[3].transform.position += Vector3.right * 150;
                    LandArray[6].transform.position += Vector3.right * 150;

                    System.Array.Copy(_LandArray, LandArray, 9);
                }
                break;
            case 3:
                {
                    transform.position += Vector3.back * LandSize;

                    _LandArray[0] = LandArray[3];
                    _LandArray[1] = LandArray[4];
                    _LandArray[2] = LandArray[5];
                    _LandArray[3] = LandArray[6];
                    _LandArray[4] = LandArray[7];
                    _LandArray[5] = LandArray[8];
                    _LandArray[6] = LandArray[0];
                    _LandArray[7] = LandArray[1];
                    _LandArray[8] = LandArray[2];

                    LandArray[0].transform.position += Vector3.back * 150;
                    LandArray[1].transform.position += Vector3.back * 150;
                    LandArray[2].transform.position += Vector3.back * 150;

                    System.Array.Copy(_LandArray, LandArray, 9);
                }
                break;

        }
    }

    }

   



