using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WireObj : InteractibleElementScript {

    public GameObject cutWire;
    public int index;
    private Renderer rend;
    public AudioSource highlightWireAudioSource;
    public AudioSource cutWireAudioSource;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
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

    public override void highlightObject()
    {
        var materials = rend.sharedMaterials.ToList();

        materials.Add(outlineMaskMaterial);
        materials.Add(outlineFillMaterial);

        rend.materials = materials.ToArray();
        highlightWireAudioSource.Play();
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
        WireBox box = GameObject.FindGameObjectWithTag("Module").GetComponent<WireBox>();
        box.message = new WireMessage(index, gameObject.tag, true);
        cutWireAudioSource.Play();
        Destroy(gameObject);
    }
}
