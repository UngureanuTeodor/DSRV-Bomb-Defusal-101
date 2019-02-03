using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessModuleScript : MonoBehaviour {

    public List<int> solution = new List<int>();
    private bool left = false, right = false, up = false, down = false;
    private int currentPosition;
    public GameObject chess_solved;
    public Material status_success;

    // Use this for initialization
    void Start() {
        int noOfBatteries = GameManager.Get().getBatteriesNo();
        switch (noOfBatteries)
        {
            case 1:
                solution.Add(1);
                up = true; right = true;
                break;
            case 2:
                solution.Add(5);
                down = true; right = true;
                break;
            case 3:
                solution.Add(21);
                up = true; left = true;
                break;
            case 4:
                solution.Add(25);
                down = true; left = true;
                break;
        }

        string serialNo = GameManager.Get().getSerial();
        Debug.Log("Serial: " + serialNo);
        for (int index = 1; index < serialNo.Length - 2; index++)
        {
            currentPosition = solution[solution.Count - 1];
            char c = serialNo[index];
            bool isVowel = "AEIOU".IndexOf(c) >= 0;
            if (char.IsLetter(c))
            {
                if (isVowel)
                {
                    moveDown();
                } else
                {
                    moveUp();
                }
            } else
            {
                if ((int)char.GetNumericValue(c) % 2 == 1)
                {
                    moveLeft();
                } else
                {
                    moveRight();
                }
            }
        }
        currentPosition = 0;
    }

    private void moveUp()
    {
        int newPosition = currentPosition;
        if (up)
        {
            newPosition++;
            down = true;
        }
        solution.Add(newPosition);

        if (newPosition % 5 == 0)
        {
            up = false;
        }
    }

    private void moveDown()
    {
        int newPosition = currentPosition;
        if (down)
        {
            newPosition--;
            up = true;
        }
        solution.Add(newPosition);

        if (newPosition % 5 == 1)
        {
            down = false;
        }
    }

    private void moveLeft()
    {
        int newPosition = currentPosition;
        if (left)
        {
            newPosition -= 5;
            right = true;
        }
        solution.Add(newPosition);

        if (newPosition < 6)
        {
            left = false;
        }
    }

    private void moveRight()
    {
        int newPosition = currentPosition;
        if (right)
        {
            newPosition += 5;
            left = true;
        }
        solution.Add(newPosition);

        if (newPosition > 20)
        {
            right = false;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public bool OnButtonClicked(string buttonIndex)
    {
        int buttonPressed = System.Int32.Parse(buttonIndex);
        if (buttonPressed == solution[currentPosition])
        {
            currentPosition++;
            Debug.Log(buttonIndex + " is correct");
            if (currentPosition == solution.Count)
            {
                Debug.Log("Solved");
                chess_solved.GetComponent<Renderer>().material = status_success;
                GameManager.Get().finishedModule();
            }
            return true;
        } else
        {
            Debug.Log("mistake");
            GameManager.Get().strike();
        }

        return false;
    }
}
