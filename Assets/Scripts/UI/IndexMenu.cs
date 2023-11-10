using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="index")]
public class IndexMenu : ScriptableObject
{
    [SerializeField] private int _index;

    public int Index
    {
        get
        {
            return _index;
        }
        set
        {
            _index = value;
        }
    }
}
