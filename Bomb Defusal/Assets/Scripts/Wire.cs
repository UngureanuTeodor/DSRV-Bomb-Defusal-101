using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

    public GameObject RemovableObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HingeJoint joint = RemovableObject.GetComponent<HingeJoint>();
            joint.connectedBody = null;
        }
    }
}
