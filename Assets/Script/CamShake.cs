using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CamShake : MonoBehaviour
{
    public float ShakeDuration = 0.3f; // 카메라 흔들림이 지속되는 시간
    public float ShakeAmplitube = 1.2f; // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f; // Cinemachine Noise Profile Parameter

    private float ShakeElapsedTime = 0f;
    private float targetOrtho;
    private int count;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    

    void Start()
    {
        if(VirtualCamera != null)
        {
            
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

            targetOrtho = VirtualCamera.m_Lens.OrthographicSize;
            
        }
        
    }

    
    void Update()
    {
        
        

        if (VirtualCamera != null || virtualCameraNoise != null)
        {
            if (ShakeElapsedTime > 0)
            {
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitube; 
                virtualCameraNoise.m_AmplitudeGain = ShakeFrequency;

                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }

   
      
    }

    public void camShake()
    {
        


            ShakeElapsedTime = ShakeDuration;
        
      
    }
}
