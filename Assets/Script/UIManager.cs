using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    //---------------------------------------------------------
    #region 싱글톤
    private UIManager() { }

    static UIManager instance;

    public static UIManager Inst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                {
                    instance = new GameObject("UIManager").AddComponent<UIManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    //-------------------------------------------------------------------



    public bool isGameover { get; set; } // 게임 오버 상태

    public float energy = 100f;

    public float UISpeed;

    public int score;
    
    private PlayerMove player;
    [SerializeField]
    private Image EnergyUI;
    [SerializeField]
    private Image SpeedUI;
    [SerializeField]
    private Image OverSpeedUI;
    [SerializeField]
    private Text ScoreUI;
    [SerializeField]
    private Text SpeedText;

    private Text TimeText;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>();
       

    }

    void Update()
    {


        Energy();
        Speed();

        

    }


    //연료 게이지 // 시간으로 감

    public void Energy()
    {
        energy -= Time.deltaTime;

        EnergyUI.fillAmount = energy / 100F;

        if (energy <= 0)
        {
            isGameover = true;
        }
    }


    //속도 게이지 // 플레이어 speed로 계산
    public void Speed()
    {
        UISpeed = player.speed;
        float OverUISpeed = player.speed - 10f;

        SpeedUI.fillAmount = UISpeed / 10f;
        if(UISpeed > 9f)
        {

        OverSpeedUI.fillAmount = OverUISpeed / 5f;
        }

        

        SpeedText.text = "SPEED\n" + (int)player.speed;
    }

 
    public void Score(int dir)
    {
        score += dir;
        ScoreUI.text = "Score : " + score;
    }

 
   


}
