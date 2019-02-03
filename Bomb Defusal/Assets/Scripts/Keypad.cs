using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Keypad : InteractibleElementScript
{

    public Material status_idle;
    public Material status_success;
    public Material status_error;
    public GameObject keypad_solved;

    bool clickedOk = false;

    private Renderer rend;
    public AudioSource highlightButtonAudioSource;
    public AudioSource pressButtonAudioSource;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
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
        if (!clickedOk)
        {
            int index_module = -1;

            if (transform.gameObject.tag == "keypad0")
            {
                index_module = Keypads.GetIndexModule_0();
            }
            else if (transform.gameObject.tag == "keypad1")
            {
                index_module = Keypads.GetIndexModule_1();
            }
            else if (transform.gameObject.tag == "keypad2")
            {
                index_module = Keypads.GetIndexModule_2();
            }
            else if (transform.gameObject.tag == "keypad3")
            {
                index_module = Keypads.GetIndexModule_3();
            }

            Debug.Log(index_module + " - " + Keypads.GetMinList());

            // Verificam daca e OK
            if (index_module == Keypads.GetMinList())
            {
                GameObject child = transform.GetChild(0).gameObject;
                child.GetComponent<Renderer>().material = status_success;
                Keypads.PopFromOrder(index_module);

                clickedOk = true;

                if (Keypads.order.Count == 0)
                {
                    keypad_solved.GetComponent<Renderer>().material = status_success;
                    GameManager.Get().finishedModule();
                }
            }
            else
            {
                GameObject child = transform.GetChild(0).gameObject;
                child.GetComponent<Renderer>().material = status_error;

                GameManager.Get().strike();
            }
        }
    }
}
