using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessButtonScript : InteractibleElementScript {

    private GameObject parent;
    private Renderer rend;
    public AudioSource highlightButtonAudioSource;
    public AudioSource pressButtonAudioSource;

    // Use this for initialization
    void Start () {
        parent = GameObject.Find("chessModule");
        rend = GetComponent<Renderer>();

    }

    public override void highlightObject()
    {
        //Debug.Log("Here");
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
        bool result = parent.GetComponent<ChessModuleScript>().OnButtonClicked(gameObject.transform.name);
        pressButtonAudioSource.Play();
        if (result)
        {
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.green);
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.green);
        }
    }
}
