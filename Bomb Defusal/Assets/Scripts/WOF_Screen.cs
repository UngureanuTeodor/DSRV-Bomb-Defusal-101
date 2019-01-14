using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WOF_Screen {

    string name;
    int position;

    public WOF_Screen(string _name, int _position) {
        name = _name;
        position = _position;
    }

    public void SetName(string _name) {
        name = _name;
    }

    public string GetName() {
        return name;
    }

    public void SetPosition(int _position)
    {
        position = _position;
    }

    public int GetPosition()
    {
        return position;
    }
}
