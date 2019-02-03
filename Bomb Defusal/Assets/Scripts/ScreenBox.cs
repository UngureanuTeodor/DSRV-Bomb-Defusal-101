using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenBox : MonoBehaviour {

    public GameObject Screen;
    public GameObject Stage;
    public GameObject FirstButton;
    public GameObject SecondButton;
    public GameObject ThirdButton;
    public GameObject FourthButton;

    private TextMesh _screenMesh;
    private TextMesh _stageMesh;

    private int _currentStep { get; set; }
    private int _screenDisplay { get; set; }
    public PressedButton PressedButton { get; set; }

    private int[] _valueByOrder;
    private Dictionary<int, PressedButton> _steps { get; set; }

    public GameObject screen_solved;
    public Material status_success;

    // Use this for initialization
    void Start () {
        PressedButton = new PressedButton(false, -1);
        _steps = new Dictionary<int, PressedButton>();
        _valueByOrder = new int[4];
        _valueByOrder[0] = int.Parse(FirstButton.GetComponentInChildren<TextMesh>().text);
        _valueByOrder[1] = int.Parse(SecondButton.GetComponentInChildren<TextMesh>().text);
        _valueByOrder[2] = int.Parse(ThirdButton.GetComponentInChildren<TextMesh>().text);
        _valueByOrder[3] = int.Parse(FourthButton.GetComponentInChildren<TextMesh>().text);
        for(var i = 0; i < _valueByOrder.Length; i++)
        {
            Debug.Log(_valueByOrder[i]);
        }
        _currentStep = 1;
        _screenDisplay = UnityEngine.Random.Range(1, 5);
        _screenMesh = Screen.GetComponentInChildren<TextMesh>();
        _screenMesh.text = _screenDisplay.ToString();

        _stageMesh = Stage.GetComponentInChildren<TextMesh>();
        _stageMesh.text = "1";
    }

    void Update()
    {
        if (_currentStep < 6)
        {
            //Debug.Log("Trebuie apasat " + ComputeSteps());
            if (PressedButton.NewMessage)
            {
                if (PressedButton.Label == ComputeSteps())
                {
                    _steps.Add(_currentStep, PressedButton);
                    _currentStep++;
                }
                else
                {
                    _currentStep = 1;
                    _steps.Clear();
                    GameManager.Get().strike();
                }

                _screenDisplay = UnityEngine.Random.Range(1, 5);
                _screenMesh.text = _screenDisplay.ToString();
                PressedButton.NewMessage = false;
                _stageMesh.text = _currentStep.ToString();
            }

        }
        else if (_currentStep == 6)
        {
            Debug.Log("Screen Solved");
            screen_solved.GetComponent<Renderer>().material = status_success;
            GameManager.Get().finishedModule();
            _currentStep++;
        }
    }

    public int ComputeSteps()
    {
        switch (_currentStep)
        {
            case 1:
                return FirstStep();
            case 2:
                return SecondStep();
            case 3:
                return ThirdStep();
            case 4:
                return FourthStep();
            case 5:
                return FifthStep();
            default:
                return 0;
        }
    }

    public int FirstStep()
    {
        switch (_screenDisplay)
        {
            case 1:
                return _valueByOrder[1];
            case 2:
                return _valueByOrder[1];
            case 3:
                return _valueByOrder[2];
            case 4:
                return _valueByOrder[3];
            default:
                return 0;
        }
    }

    public int SecondStep()
    {
        switch (_screenDisplay)
        {
            case 1:
                return 4;
            case 2:
                return _steps[1].Label;
            case 3:
                return _valueByOrder[0];
            case 4:
                return _steps[1].Label;
            default:
                return 0;
        }
    }

    public int ThirdStep()
    {
        switch (_screenDisplay)
        {
            case 1:
                return _steps[2].Label;
            case 2:
                return _steps[1].Label;
            case 3:
                return _valueByOrder[2];
            case 4:
                return 4;
            default:
                return 0;
        }
    }

    public int FourthStep()
    {
        switch (_screenDisplay)
        {
            case 1:
                return _steps[1].Label;
            case 2:
                return _valueByOrder[0];
            case 3:
                return _steps[2].Label;
            case 4:
                return _steps[2].Label;
            default:
                return 0;
        }
    }

    public int FifthStep()
    {
        switch (_screenDisplay)
        {
            case 1:
                return _steps[1].Label;
            case 2:
                return _steps[2].Label;
            case 3:
                return _steps[4].Label;
            case 4:
                return _steps[3].Label;
            default:
                return 0;
        }
    }
}

public class PressedButton
{
    public bool NewMessage { get; set; }
    public int Label { get; set; }

    public PressedButton(bool NewMessage, int Label)
    {
        this.NewMessage = NewMessage;
        this.Label = Label;
    }
}
