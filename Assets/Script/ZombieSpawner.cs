using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    public Zombie zombiePrefab;
    [SerializeField]
    private PlayerMove player;
    private Zombie zombie;
    float timeAfterSpawn;
    float spawnRate;


    
    void Start()
    {
        //player = GetComponent<PlayerMove>();
        spawnRate = Random.Range(0.6f, 1f);
    }

    


    private void Update()
    {
        CreateZombie();
    }

    private void CreateZombie()
    {
        float Spawn_x = Random.Range(-5f,5f), Spawn_z= Random.Range(-5f, 5f);

        //생성할 위치를 랜덤으로 결정

        
        
        Vector3 SpawnPoint = new Vector3(Spawn_x,0,Spawn_z)+ player.transform.position;

        
        
        //좀비 프리팹으로부터 좀비 생성
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            ObjectPool.Instance.CreateZombie(SpawnPoint);
           
            spawnRate = Random.Range(0.6f,1f);
        }
        
    }
}
