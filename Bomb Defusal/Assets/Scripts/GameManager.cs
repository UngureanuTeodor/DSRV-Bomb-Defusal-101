using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    private int strikesLeft = 3;
    private bool alive = true;
    public GameObject bomb, serialPlaceholder;
    public GameObject controllerLeft, controllerRight;
    public GameObject manual;
    private int bombSelectedByController = -1;

    public GameObject explosion;
    public Transform explosionPoint;

    public AudioSource explosionAudioSource;
    public AudioSource strikeAudioSource;
    public AudioSource moduleSuccessAudioSource;

    public static GameManager Get()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        if(bomb == null)
        {
            bomb = GameObject.Find("Bombv3");
        }
        if(serialPlaceholder == null)
        {
            serialPlaceholder = GameObject.Find("serialPlaceholder");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (alive)
        {
            if (strikesLeft == 0)
            {
                LoseGame("BOOM! No strikes left!");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                alive = true;
                // explosion.Stop();
                explosionAudioSource.Stop();
                Destroy(explosion);

                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
	}

    public void LoseGame(string message)
    {
        GameObject messageUI = GameObject.Find("Message");
        messageUI.GetComponent<Text>().text = message;
        alive = false;

        explosionAudioSource.Play();
        GameObject instantiated = Instantiate(explosion, explosionPoint.position, Quaternion.identity);
    }

    public int getBatteriesNo()
    {
        return bomb.GetComponent<BombScript>().getNoOfBatteries();
    }

    public string getSerial()
    {
        return serialPlaceholder.GetComponent<SerialScript>().getSerial();
    }

    public void strike()
    {
        if (strikesLeft > 0)
        {
            strikesLeft--;
            GameObject strikesUI = GameObject.Find("Strikes");
            string existingText = strikesUI.GetComponent<Text>().text;
            strikesUI.GetComponent<Text>().text = existingText + "  X";
            strikeAudioSource.Play();
        }
    }

    public void selectBomb(int controllerIndex)
    {
        bombSelectedByController = controllerIndex;
        bomb.GetComponent<BoxCollider>().enabled = false;
        if(controllerIndex == 0)
        {
            controllerRight.GetComponent<ControllerTriggerAction>().setHasLaser(true);
        } else
        {
            controllerLeft.GetComponent<ControllerTriggerAction>().setHasLaser(true);
        }
    }

    public void deselectBomb()
    {
        bombSelectedByController = -1;
        bomb.GetComponent<BoxCollider>().enabled = true;
        controllerRight.GetComponent<ControllerTriggerAction>().setHasLaser(false);
        controllerLeft.GetComponent<ControllerTriggerAction>().setHasLaser(false);
    }

    public void finishedModule()
    {
        moduleSuccessAudioSource.Play();
    }
}
