using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WOF_Button {

    string name;
    List<string> dictionary;

    public WOF_Button(string _name, List<string> _dictionary) {
        name = _name;
        dictionary = _dictionary;
    }
    
    public void SetName(string _name)
    {
        name = _name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetDictionary(List<string> _dictionary)
    {
        dictionary = _dictionary;
    }

    public List<string> GetDictionary()
    {
        return dictionary;
    }
}
