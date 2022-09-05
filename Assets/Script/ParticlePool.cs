using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
 
    #region 싱글톤
    private static ParticlePool instance = null; //static으로 싱글톤 클래스 유일 선언
    public static ParticlePool Inst //프로퍼티 선언
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
            return instance;// 인스턴스의 값이 null이 아니라면 SingletonClass 오브젝트를 찾아 _instance에 할당합니다.
        }
    }
    #endregion

    [SerializeField] GameObject ParticlePrefab;

    Queue<GameObject> pool = new Queue<GameObject>();
    

    public GameObject CreateParticle(Vector3 pos)
    {


        GameObject instParticle;
        // 처음에는 아무것도 없으니 생성하자
        if (pool.Count ==
            0)
        {
            // 인스턴시레이트로 생성할 프리팹을 직접 Resources에 있는 몬스터 프리팹을 직접 가져옴
            //로드한 프리팹을 이용해서 인스턴트 객체 한개를 만든다.

            instParticle = Instantiate(ParticlePrefab, pos, Quaternion.identity);

            return instParticle;
        }



        // 기존의 목록 중에서 비활성화 된 것을 찾는다.
        // 지금 큐에서는 맨 앞에 있는 것 하나를 전달해 주면
        instParticle = pool.Dequeue();
        instParticle.transform.parent = null;
        instParticle.transform.position = pos;
        instParticle.transform.rotation = Quaternion.identity;
        instParticle.gameObject.SetActive(true);
        return instParticle;
    }

    public void DestroyParticle(GameObject particle)
    {
        //particle.transform.parent = this.transform; // 없는 부모를 만들어줌
        particle.gameObject.SetActive(false);
        pool.Enqueue(particle); // pool 에 1개 늘어난다.
        particle.transform.parent = transform;


    }

}
