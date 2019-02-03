using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenBoxButton : InteractibleElementScript {

    private Renderer rend;
    public AudioSource highlightButtonAudioSource;
    public AudioSource pressButtonAudioSource;

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
        TextMesh textMesh = this.gameObject.GetComponentInChildren<TextMesh>();
        ScreenBox box = GameObject.FindGameObjectWithTag("ScreenModule").GetComponent<ScreenBox>();
        box.PressedButton = new PressedButton(true, int.Parse(textMesh.text));
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
        TextMesh textMesh = this.gameObject.GetComponentInChildren<TextMesh>();
        ScreenBox box = GameObject.FindGameObjectWithTag("ScreenModule").GetComponent<ScreenBox>();
        box.PressedButton = new PressedButton(true, int.Parse(textMesh.text));
        pressButtonAudioSource.Play();
    }
}
