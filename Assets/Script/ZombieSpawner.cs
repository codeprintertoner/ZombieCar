using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    //[SerializeField]
    //public Zombie zombiePrefab;
    [SerializeField]
    private PlayerMove player;
    float timeAfterSpawn;
    float spawnRate;


    
    void Start()
    {
        // ���� ���� �����ð�
        spawnRate = Random.Range(0.6f, 1f);
    }

    


    private void Update()
    {
        //���� �����Ѵ�.
        CreateZombie();
    }

    
    private void CreateZombie()
    {
        // ���� ���� ��ǥ
        float Spawn_x = Random.Range(-5f,5f), Spawn_z= Random.Range(-5f, 5f);
        Vector3 SpawnPoint = new Vector3(Spawn_x,0,Spawn_z)+ player.transform.position;

        
        
        
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            //timeAfterSpawn �ʱ�ȭ
            timeAfterSpawn = 0f;
            //������Ʈ Ǯ���� �÷��̾� �������� ���� ���� ����
            ObjectPool.Instance.CreateZombie(SpawnPoint);
            //�����ֱ� �������� �ٽ��ֱ�.
            spawnRate = Random.Range(0.6f,1f);
        }
        
    }
}
