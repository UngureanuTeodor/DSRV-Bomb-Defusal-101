using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fare;

public class SerialScript : MonoBehaviour {

    private string pattern = "^S[A-Z0-9]{7}[0-9]{2}$";
    public TextMesh serialMesh;
    private string generatedString;

    void Awake()
    {
        var xeger = new Xeger(pattern);
        generatedString = xeger.Generate();
    }

    // Use this for initialization
    void Start () {
        serialMesh.text = generatedString;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getSerial()
    {
        return generatedString;
    }
}
