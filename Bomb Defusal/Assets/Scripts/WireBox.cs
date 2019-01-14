using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBox : MonoBehaviour {

    // Use this for initialization
    public string serialNo;
    private Dictionary<string, int> _apperances { get; set; }

    private bool _wiresDeactivated { get; set; }

    public WireMessage message;
    private GameObject[] _wires;
    private int _wireToBeCut;
    private string[] sortedWires;
	void Start () {
        _wiresDeactivated = false;
        _apperances = new Dictionary<string, int>();
        _wires = GameObject.FindGameObjectsWithTag("Wire");
        message = new WireMessage(0, string.Empty, false);
        sortedWires = new string[_wires.Length];

        
        for(var i = 0; i < _wires.Length; i++)
        {
            WireObj val = _wires[i].GetComponentInChildren<WireObj>();
            string color = _wires[i].ToString().Replace("Wire", string.Empty).Replace(" (UnityEngine.GameObject)", string.Empty);
            sortedWires[val.index - 1] = color;
            if (!_apperances.ContainsKey(color))
            {
                _apperances.Add(color, 1);
            }
            else
            {
                _apperances[color]++;
            }
        }

        _wireToBeCut = ComputeWires();

        //Debug.Log(_wireToBeCut);
	}
	
	// Update is called once per frame
	void Update () {
        if (message.newMessage)
        {
            message.newMessage = false;
            if (!_wiresDeactivated)
            {
                if (message.wirePosition == _wireToBeCut) { 
                    _wiresDeactivated = true;
                }
                else
                {
                    Debug.Log("BOOM");
                }
            }
            else
            {
                Debug.Log("BOOM");
            }
        }
	}

    private int ComputeWires()
    {
        switch (sortedWires.Length)
        {
            case 3:
                return ComputeThreeWires();
            case 4:
                return ComputeFourWires();
            default:
                return 0;
        }
    }

    private int ComputeThreeWires()
    {
        if (!_apperances.ContainsKey("Red"))
        {
            return 2;
        }
        else if(string.Equals(sortedWires[2], "White"))
        {
            return 3;
        }
        else if(_apperances.ContainsKey("Blue") && _apperances["Blue"] > 1)
        {
            return GetLastOfColor("Blue");
        }
        else
        {
            return 3;
        }
    }

    private int ComputeFourWires()
    {
        if(_apperances.ContainsKey("Red") && _apperances["Red"] > 1 && int.Parse(serialNo[serialNo.Length - 1].ToString()) % 2 != 0){
            return GetLastOfColor("Red");
        }
        else if(string.Equals(sortedWires[3], "Yellow") && !_apperances.ContainsKey("Red"))
        {
            return 1;
        }
        else if(_apperances.ContainsKey("Blue") && _apperances["Blue"] == 1)
        {
            return 1;
        }
        else if(_apperances.ContainsKey("Yellow") && _apperances["Yellow"] > 1)
        {
            return 4;
        }
        else
        {
            return 2;
        }
    }


    private int GetLastOfColor(string color)
    {
        int index = 0;
        for (var i = 0; i < sortedWires.Length; i++)
        {
            if (string.Equals(sortedWires[i], color))
            {
                index = i + 1;
            }
        }

        return index;
    }
}

public class WireMessage
{
    public bool newMessage { get; set; }

    public int wirePosition { get; set; }

    public string color { get; set; }

    public WireMessage(int wirePosition, string color, bool newMessage)
    {
        this.wirePosition = wirePosition;
        this.color = color;
        this.newMessage = newMessage;
    }
}
