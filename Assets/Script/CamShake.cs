using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CamShake : MonoBehaviour
{
    public float ShakeDuration = 0.3f; // ī�޶� ��鸲�� ���ӵǴ� �ð�
    public float ShakeAmplitube = 1.2f; // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 2.0f; // Cinemachine Noise Profile Parameter

    private float ShakeElapsedTime = 0f; // ����ð�
    

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera; 
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    

    void Start()
    {
        if(VirtualCamera != null)//����ó��
        {
            
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

            
            
        }
        
    }
    public void camShake() // ���� ���� �ڷ�ƾ �Լ����� ������ ����ð��� 0.3�ʷ� ������� 
    {

        ShakeElapsedTime = ShakeDuration; 

    }

    void Update()
    {
        
        if (VirtualCamera != null || virtualCameraNoise != null) //����ó��
        {
            if (ShakeElapsedTime > 0)
            {
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitube; // ī�޶� ���� 
                virtualCameraNoise.m_AmplitudeGain = ShakeFrequency; // ī�޶� ����  �ֵΰ������� �˾ƺ���

                ShakeElapsedTime -= Time.deltaTime; // ��� �ð�
            }
            else
            {
                virtualCameraNoise.m_AmplitudeGain = 0f; // ī�޶� ����鸲
                ShakeElapsedTime = 0f; // ����ô� 0���� ����
            }
        }     
    }

   
}
