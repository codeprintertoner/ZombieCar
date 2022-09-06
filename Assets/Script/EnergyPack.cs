using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPack : MonoBehaviour, IItem
{

    public void Use(GameObject taget)
    {
        PlayerMove playermove = taget.GetComponent<PlayerMove>();

        playermove.energyPlus += 5f;

        Destroy(gameObject);
    }

}
