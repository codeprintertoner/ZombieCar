using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// item인터페이스 + itemSpawner 만들기 
// 1 . 가속도 + 속도안줄음
// 2. 연료 게이지 ++


public interface IItem
{
    void Use(GameObject targt);
}


