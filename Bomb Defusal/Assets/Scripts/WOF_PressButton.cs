using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOF_PressButton : MonoBehaviour {

    public Material status_success;
    public GameObject whosOnFirst_solved;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseOver()
    {
        if (!WhosOnFirst.gameSolved)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (transform.gameObject.tag == ("button_" + WhosOnFirst.solvedModule_buttonIndex))
                {
                    whosOnFirst_solved.GetComponent<Renderer>().material = status_success;
                    Debug.Log("Done");
                    WhosOnFirst.gameSolved = true;
                }
                else
                {
                    Debug.Log("Wrong");
                    GameManager.Get().strike();
                }
            }
        }
    }
}
