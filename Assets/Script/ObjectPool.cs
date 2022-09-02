using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] Zombie ZombiePrefab;


    #region �̱���
    private static ObjectPool _instance = null; //static���� �̱��� Ŭ���� ���� ����
    public static ObjectPool Instance //������Ƽ ����
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ObjectPool>();

                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<ObjectPool>();
                }
            }
            return _instance;// �ν��Ͻ��� ���� null�� �ƴ϶�� SingletonClass ������Ʈ�� ã�� _instance�� �Ҵ��մϴ�.
        }
    }
    #endregion


    Queue<Zombie> pool = new Queue<Zombie>();


    private void Awake()
    {
        
    }

    public Zombie CreateZombie(Vector3 pos)
    {
        

        Zombie instMob;
        // ó������ �ƹ��͵� ������ ��������
        if (pool.Count == 0)
        {
            // �ν��Ͻ÷���Ʈ�� ������ �������� ���� Resources�� �ִ� ���� �������� ���� ������
            //�ε��� �������� �̿��ؼ� �ν���Ʈ ��ü �Ѱ��� �����.
            instMob = Instantiate(ZombiePrefab, pos, Quaternion.identity);
            
            //���� ����
            //�ٸ��� ����
            
            return instMob;
        }

        

        // ������ ��� �߿��� ��Ȱ��ȭ �� ���� ã�´�.
        // ���� ť������ �� �տ� �ִ� �� �ϳ��� ������ �ָ�
        instMob = pool.Dequeue();
        instMob.transform.parent = null;
        instMob.transform.position = pos;
        instMob.transform.rotation = Quaternion.identity;
        instMob.gameObject.SetActive(true);
        return instMob;
    }

    public void DestroyZombie(Zombie zombie)
    {
        zombie.transform.parent = this.transform; // ���� �θ� �������
        zombie.gameObject.SetActive(false);
        pool.Enqueue(zombie); // pool �� 1�� �þ��.


    }

}
