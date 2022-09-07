using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScenes : MonoBehaviour
{
    //Ÿ��Ʋ�� ��ŸƮ ���� ����
    static void StartGame()
    {
        GameObject.Find("START").GetComponentInChildren<Text>().text = "START";
    }
    
    static void QuitGame()
    {
        GameObject.Find("Quit_Button").GetComponentInChildren<Text>().text = "Quit";
    }
    // �÷��̸� ������ ���� ���Ӿ��� �ε��Ѵ�.
    static public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    static public void Quit()
    {
        Application.Quit();
    }
    
  }