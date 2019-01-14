using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    private float elapsedTime = 600;
    public TextMesh textMesh;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0)
        {
            GameManager.LoseGame("BOOM! No time left!");
        }
        else
        {
            int minutes = (int)elapsedTime / 60;
            int seconds = (int)elapsedTime % 60;
            string minutesText = (minutes < 10 ? "0" : "") + minutes.ToString();
            string secondsText = (seconds < 10 ? "0" : "") + seconds.ToString();

            textMesh.text = minutesText + ":" + secondsText;
        }
	}
}
