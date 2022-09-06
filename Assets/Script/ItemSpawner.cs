using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items; //생성할 아이템



    

    // 실제 아이템 생성 처리
    public void Spawn(Vector3 zombie)
    {
        // 플레이어 근처에서 내비메시 위의 랜덤 위치 가져오기
        Vector3 spawnPosition = zombie;
        spawnPosition.y = 0;
        int SpawnRand = Random.Range(0, 10);

        
        if (SpawnRand == 1 || SpawnRand == 5)
        {
            // 아이템 중 하나를 무작위로 골라 랜덤 위치에 생성
        GameObject selectedItem = items[Random.Range(0, items.Length)];
            Instantiate(selectedItem, spawnPosition, Quaternion.identity);

        }

        
        // 생성된 아이템을 5초 뒤에 파괴

        //Destroy(item, 5f);
    }

}
