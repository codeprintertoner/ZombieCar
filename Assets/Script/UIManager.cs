using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; } // 게임 오버 상태

    float energy = 100f;

    private PlayerMove player;
    
    


    private void Update()
    {

        energy -= Time.deltaTime;
        if(energy <= 0)
        {
            isGameover = true;
        }



    }


    //연료 게이지 // 시간으로 감
    



    //속도 게이지 // 플레이어 speed로 계산
    

}
