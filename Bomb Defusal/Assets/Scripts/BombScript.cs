using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    public float smooth = 1f;
    private Quaternion targetRotation;
    private int noOfBatteries = 4;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    // Declaring variables
    bool crossedBoundary;
    bool isRotated = false;

    public TextMesh PressToFocusText;

    //void OnTriggerEnter(Collider other)
    //{
    //    // Telling game to activate boolean
    //    if (other.gameObject.tag == "Player")
    //    {
    //        PressToFocusText.gameObject.SetActive(true);
    //        crossedBoundary = true;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    // Telling game to activate boolean
    //    if (other.gameObject.tag == "Player")
    //    {
    //        PressToFocusText.gameObject.SetActive(false);
    //        crossedBoundary = false;
    //    }
    //}

    void Update()
    {
        //if (crossedBoundary == true)
        //{
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isRotated)
                {
                    targetRotation *= Quaternion.AngleAxis(60, Vector3.left);
                    transform.Translate(Vector3.up, Space.World);
                    PressToFocusText.gameObject.SetActive(false);

                    transform.position += new Vector3(1.0f, -0.25f, 0.0f);
                }
                else
                {
                    targetRotation *= Quaternion.AngleAxis(-60, Vector3.left);
                    transform.Translate(-Vector3.up, Space.World);
                    PressToFocusText.gameObject.SetActive(true);

                    transform.position -= new Vector3(1.0f, -0.25f, 0.0f);
                }

                isRotated = !isRotated;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
        //}
    }

    public int getNoOfBatteries()
    {
        return noOfBatteries;
    }
}
