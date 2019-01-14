using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour {

    public Material status_idle;
    public Material status_success;
    public Material status_error;

    bool clickedOk = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
                }
                else
                {
                    GameObject child = transform.GetChild(0).gameObject;
                    child.GetComponent<Renderer>().material = status_error;
                }
            }

        }
    }
}
