using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPack : MonoBehaviour, IItem
{
    // �������̽��� ����� ������ ����
    
    public float overspeed = 15f;//���ǵ����� �Ծ����� �ӷ�
    public void Use(GameObject taget)
    { 
        
        PlayerMove playermove = taget.GetComponent<PlayerMove>();
        //�÷��̾� ���ǵ带 �������ǵ�� ������ش�.
        playermove.speed = overspeed;

        
        // ������Ʈ �ı�.
        Destroy(gameObject);
    }
   
}
