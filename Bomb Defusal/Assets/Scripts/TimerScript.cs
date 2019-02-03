using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    private float elapsedTime = 600;
    public TextMesh textMesh;
    private int lastSeconds = -1;
    public AudioSource timerAudioSource;
    public AudioSource lastSecondsAudioSource;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0)
        {
            GameManager.Get().LoseGame("BOOM! No time left!");
        }
        else
        {
            int minutes = (int)elapsedTime / 60;
            int seconds = (int)elapsedTime % 60;
            string minutesText = (minutes < 10 ? "0" : "") + minutes.ToString();
            string secondsText = (seconds < 10 ? "0" : "") + seconds.ToString();
            if(lastSeconds > -1 && lastSeconds != seconds)
            {
                if(seconds <= 10 && minutes == 0)
                {
                    lastSecondsAudioSource.Play();
                } else
                {
                    timerAudioSource.Play();
                }
            }

            textMesh.text = minutesText + ":" + secondsText;
            lastSeconds = seconds;
        }
	}
}
