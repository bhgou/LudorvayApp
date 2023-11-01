using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Guide")]

public class GuideScriptable : ScriptableObject
{
    [TextArea]
    [SerializeField] private string _info;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private AudioClip _audio;
    public string Info
    {
        get
        {
            return _info;
        }
    }

    public Sprite Image
    {
        get
        {
            return _image;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public AudioClip Audio
    {
        get
        {
            return _audio;
        }
    }
}
