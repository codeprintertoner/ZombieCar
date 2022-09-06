using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items; //������ ������



    

    // ���� ������ ���� ó��
    public void Spawn(Vector3 zombie)
    {
        // �÷��̾� ��ó���� ����޽� ���� ���� ��ġ ��������
        Vector3 spawnPosition = zombie;
        spawnPosition.y = 0;
        int SpawnRand = Random.Range(0, 10);

        
        if (SpawnRand == 1 || SpawnRand == 5)
        {
            // ������ �� �ϳ��� �������� ��� ���� ��ġ�� ����
        GameObject selectedItem = items[Random.Range(0, items.Length)];
            Instantiate(selectedItem, spawnPosition, Quaternion.identity);

        }

        
        // ������ �������� 5�� �ڿ� �ı�

        //Destroy(item, 5f);
    }

}
