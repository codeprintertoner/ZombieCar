using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private int score = 0; // ���� ���� ����
    public bool isGameover { get; private set; } // ���� ���� ����

    float energy = 100f;

    private PlayerMove player;
    
    


    private void Update()
    {

        energy -= Time.deltaTime;
        if(energy <= 0)
        {
            isGameover = true;
        }



    }


    //���� ������ // �ð����� ��
    



    //�ӵ� ������ // �÷��̾� speed�� ���
    

}
