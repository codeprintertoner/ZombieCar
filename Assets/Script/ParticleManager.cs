using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    //----------------------------------------------------------------------
    #region ╫л╠шео
    private ParticleManager() { }
    static ParticleManager instance = null;
    public static ParticleManager Inst
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ParticleManager>(true);
                
                if (instance == null)
                {
                    instance = new GameObject("ParticleManager").AddComponent<ParticleManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    //----------------------------------------------------------------------
    
    
   



    void Start()
    {
        gameObject.SetActive(false);

    }

   



    public void offParticle()
    {
        
        gameObject.SetActive(false);

    }

    public void OnParticle()
    {
        
        gameObject.SetActive(true);
    }
}
