using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    private int noOfBatteries = 4;

    void Start()
    {
    }

    void Update()
    {
    }

    public int getNoOfBatteries()
    {
        return noOfBatteries;
    }
}
