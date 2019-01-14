using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireObj : MonoBehaviour {

    public GameObject cutWire;
    public int index;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {
        //colorForCut = gameObject.tag;
        WireBox box = GameObject.FindGameObjectWithTag("Module").GetComponent<WireBox>();
        box.message = new WireMessage(index, gameObject.tag, true);
        Destroy(gameObject);
    }
}
