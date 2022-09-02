using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] Zombie ZombiePrefab;


    #region 싱글톤
    private static ObjectPool _instance = null; //static으로 싱글톤 클래스 유일 선언
    public static ObjectPool Instance //프로퍼티 선언
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
            return _instance;// 인스턴스의 값이 null이 아니라면 SingletonClass 오브젝트를 찾아 _instance에 할당합니다.
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
        // 처음에는 아무것도 없으니 생성하자
        if (pool.Count == 0)
        {
            // 인스턴시레이트로 생성할 프리팹을 직접 Resources에 있는 몬스터 프리팹을 직접 가져옴
            //로드한 프리팹을 이용해서 인스턴트 객체 한개를 만든다.
            instMob = Instantiate(ZombiePrefab, pos, Quaternion.identity);
            
            //팔을 붙힘
            //다리를 붙힘
            
            return instMob;
        }

        

        // 기존의 목록 중에서 비활성화 된 것을 찾는다.
        // 지금 큐에서는 맨 앞에 있는 것 하나를 전달해 주면
        instMob = pool.Dequeue();
        instMob.transform.parent = null;
        instMob.transform.position = pos;
        instMob.transform.rotation = Quaternion.identity;
        instMob.gameObject.SetActive(true);
        return instMob;
    }

    public void DestroyZombie(Zombie zombie)
    {
        zombie.transform.parent = this.transform; // 없는 부모를 만들어줌
        zombie.gameObject.SetActive(false);
        pool.Enqueue(zombie); // pool 에 1개 늘어난다.


    }

}
