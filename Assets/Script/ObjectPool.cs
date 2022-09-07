using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] Zombie ZombiePrefab;

    private ObjectPool() { }
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

    public Zombie CreateZombie(Vector3 pos)
    {


        Zombie instMob;
        // Ǯ�� �ƹ��͵� ������ ����
        if (pool.Count == 0)
        {
            // �ν��Ͻ÷���Ʈ�� ������ �������� �����Ѵ�.
            

            instMob = Instantiate(ZombiePrefab, pos, Quaternion.identity);
      
            return instMob;
        }

        
        
        // ������ ��� �߿��� ��Ȱ��ȭ �� ���� ã�´�.
        // ���� ť������ �� �տ� �ִ� �� �ϳ��� ������ �ָ�
        instMob = pool.Dequeue();
        instMob.transform.parent = null;
        instMob.transform.SetPositionAndRotation(pos, Quaternion.identity);
        instMob.gameObject.SetActive(true);
        return instMob;
    }

    //���� ���� ������ƮǮ�� ������ ��Ȱ��ȭ �Ѵ�.
    public void DestroyZombie(Zombie zombie) 
    {
        zombie.transform.parent = this.transform; 
        zombie.gameObject.SetActive(false);
        pool.Enqueue(zombie); // pool �� 1�� �þ��.


    }

}
