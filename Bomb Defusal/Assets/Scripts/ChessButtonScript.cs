using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessButtonScript : MonoBehaviour {

    private GameObject parent;
    private Renderer rend;

    // Use this for initialization
    void Start () {
        parent = GameObject.Find("chessModule");
        rend = GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        bool result = parent.GetComponent<ChessModuleScript>().OnButtonClicked(gameObject.transform.name);
        if(result)
        {
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.green);
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.green);
        }
    }
}
