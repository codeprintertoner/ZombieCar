using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField]
    private PlayerMove player;
    [SerializeField]
    private Rigidbody wrb;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Wheelrotate()
    {
        float turn = player.inputRotate * 45f;
        wrb.rotation *= Quaternion.Euler(0f, turn, 0f);
    }
}
