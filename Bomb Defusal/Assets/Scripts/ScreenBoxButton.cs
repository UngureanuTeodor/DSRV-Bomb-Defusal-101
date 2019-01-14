using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoxButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        //colorForCut = gameObject.tag;
        TextMesh textMesh = this.gameObject.GetComponentInChildren<TextMesh>();
        ScreenBox box = GameObject.FindGameObjectWithTag("ScreenModule").GetComponent<ScreenBox>();
        box.PressedButton = new PressedButton(true, int.Parse(textMesh.text));
    }
}
