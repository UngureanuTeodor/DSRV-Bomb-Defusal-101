using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WOF_PressButton : InteractibleElementScript
{

    public Material status_success;
    public GameObject whosOnFirst_solved;
    private Renderer rend;
    public AudioSource highlightButtonAudioSource;
    public AudioSource pressButtonAudioSource;

    // Use this for initialization
    void Start () {
        rend = gameObject.transform.parent.GetComponent<Renderer>();
    }

    public override void highlightObject()
    {
        var materials = rend.sharedMaterials.ToList();

        materials.Add(outlineMaskMaterial);
        materials.Add(outlineFillMaterial);

        rend.materials = materials.ToArray();
        highlightButtonAudioSource.Play();
    }

    public override void unhighlightObject()
    {
        var materials = rend.sharedMaterials.ToList();

        materials.Remove(outlineMaskMaterial);
        materials.Remove(outlineFillMaterial);

        rend.materials = materials.ToArray();
    }

    public override void interactWithElement()
    {
        pressButtonAudioSource.Play();
        if (!WhosOnFirst.gameSolved)
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            if (transform.gameObject.tag == ("button_" + WhosOnFirst.solvedModule_buttonIndex))
            {
                whosOnFirst_solved.GetComponent<Renderer>().material = status_success;
                GameManager.Get().finishedModule();
                Debug.Log("Done");
                WhosOnFirst.gameSolved = true;
            }
            else
            {
                Debug.Log("Wrong");
                GameManager.Get().strike();
            }
            //}
        }
    }
}
