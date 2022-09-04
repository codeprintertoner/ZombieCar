using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CamShake : MonoBehaviour
{
    public float ShakeDuration = 0.3f; // Time the Camera Shake effect will last
    public float ShakeAmplitube = 1.2f; // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f; // Cinemachine Noise Profile Parameter

    private float ShakeElapsedTime = 0f;

    private int count;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    void Start()
    {
        if(VirtualCamera != null)
        {
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }    
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            ShakeElapsedTime = ShakeDuration;
        }
        if(VirtualCamera != null || virtualCameraNoise != null)
        {
            if(ShakeElapsedTime > 0)
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
        //if (count < 5 )
        //{
            ShakeElapsedTime = ShakeDuration;
        //}
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
}
