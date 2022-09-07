using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
 
    #region �̱���
    private static ParticlePool instance = null; //static���� �̱��� Ŭ���� ���� ����
    public static ParticlePool Inst //������Ƽ ����
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ParticlePool>();

                if (instance == null)
                {
                    instance = new GameObject().AddComponent<ParticlePool>();
                }
            }
            return instance;// �ν��Ͻ��� ���� null�� �ƴ϶�� SingletonClass ������Ʈ�� ã�� _instance�� �Ҵ��մϴ�.
        }
    }
    #endregion

    [SerializeField] GameObject ParticlePrefab;

    Queue<GameObject> pool = new Queue<GameObject>();
    
    
    public GameObject CreateParticle(Vector3 pos)
    {


        GameObject instParticle;
        // ó������ �ƹ��͵� ������ ��������
        if (pool.Count == 0)
        {
            // �ν��Ͻ÷���Ʈ�� ���� ��ƼŬ ������ ����
            // �ε��� �������� �̿��ؼ� �ν���Ʈ ��ü �Ѱ��� �����.

            instParticle = Instantiate(ParticlePrefab, pos, Quaternion.identity);

            return instParticle; //GameObject Ÿ������ ��ȯ
        }



        // ������ ��� �߿��� ��Ȱ��ȭ �� ���� ã�´�.
        // ���� ť������ �� �տ� �ִ� �� �ϳ��� ������ �ָ�
        instParticle = pool.Dequeue();
        instParticle.transform.parent = null;
        instParticle.transform.SetPositionAndRotation(pos, Quaternion.identity);
        instParticle.SetActive(true);
        return instParticle;
    }

    // ����� ��ƼŬ�� ������Ʈ Ǯ�� �����´�.
    public void DestroyParticle(GameObject particle)
    {
        particle.transform.parent = this.transform; // �θ���ġ�� ����
        particle.gameObject.SetActive(false); // 
        pool.Enqueue(particle); // pool �� 1�� �þ��.


    }

}
