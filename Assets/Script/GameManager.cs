using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //----------------------------------------------------------------------
    #region ╫л╠шео
    static GameManager instance = null;
    public static GameManager Inst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    instance = new GameObject("GameMgr").AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    //----------------------------------------------------------------------

   



}
