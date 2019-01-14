using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire1 : MonoBehaviour {

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

    void OnMouseDown()
    {
        HingeJoint joint = RemovableObject.GetComponent<HingeJoint>();
        joint.connectedBody = null;
        Destroy(gameObject);
    }
}
