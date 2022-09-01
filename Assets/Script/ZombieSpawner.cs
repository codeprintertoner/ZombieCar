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


    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<PlayerMove>();
        spawnRate = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CreateZombie();
    }

    private void CreateZombie()
    {
        float Spawn_x = Random.Range(-5f,5f), Spawn_z= Random.Range(-5f, 5f);
        //������ ��ġ�� �������� ����
        Vector3 SpawnPoint = new Vector3(Spawn_x,0,Spawn_z)+ player.transform.position;
        //���� ���������κ��� ���� ����
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            zombie = Instantiate(zombiePrefab, SpawnPoint, Quaternion.identity);
            spawnRate = Random.Range(1f, 3f);
        }
        


    }
}
