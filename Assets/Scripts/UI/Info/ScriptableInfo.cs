using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info")]
public class ScriptableInfo : ScriptableObject
{   
    [SerializeField] private string _name;
   
    public string Name
    {
        get
        {
            return _name;
        }
    }

    [SerializeField] private string _info;

    public string Info
    {
        get
        {
            return _info;
        }
    }
    [SerializeField] private Sprite _image;

    public Sprite Image
    {
        get
        {
            return _image;
        }
    }
}
