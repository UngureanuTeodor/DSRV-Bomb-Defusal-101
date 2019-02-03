using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    private int noOfBatteries = 0;
    public List<GameObject> batteries;

    void Start()
    {
        for (int i = 0; i < batteries.Count; i++)
        {
            if (Random.Range(1, 100) % 2 == 0)
            {
                batteries[i].gameObject.SetActive(true);
                switch (batteries[i].gameObject.name)
                {
                    case "battery2":
                        noOfBatteries += 2;
                        break;
                    default:
                        noOfBatteries += 1;
                        break;
                }
            }
        }
        if (noOfBatteries == 0)
        {
            batteries[0].gameObject.SetActive(true);
            noOfBatteries++;
        }
        Debug.Log("Generated " + noOfBatteries + " battery/-ies");
    }

    public int getNoOfBatteries()
    {
        return noOfBatteries;
    }
}
