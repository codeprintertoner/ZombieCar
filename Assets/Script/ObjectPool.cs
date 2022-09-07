using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] Zombie ZombiePrefab;

    private ObjectPool() { }
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

    public Zombie CreateZombie(Vector3 pos)
    {


        Zombie instMob;
        // 풀에 아무것도 없을때 생성
        if (pool.Count == 0)
        {
            // 인스턴시레이트로 생성할 프리팹을 생성한다.
            

            instMob = Instantiate(ZombiePrefab, pos, Quaternion.identity);
      
            return instMob;
        }

        
        
        // 기존의 목록 중에서 비활성화 된 것을 찾는다.
        // 지금 큐에서는 맨 앞에 있는 것 하나를 전달해 주면
        instMob = pool.Dequeue();
        instMob.transform.parent = null;
        instMob.transform.SetPositionAndRotation(pos, Quaternion.identity);
        instMob.gameObject.SetActive(true);
        return instMob;
    }

    //죽은 좀비를 오브젝트풀로 가져와 비활성화 한다.
    public void DestroyZombie(Zombie zombie) 
    {
        zombie.transform.parent = this.transform; 
        zombie.gameObject.SetActive(false);
        pool.Enqueue(zombie); // pool 에 1개 늘어난다.


    }

}
