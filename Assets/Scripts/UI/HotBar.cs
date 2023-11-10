using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : MonoBehaviour
{
    [SerializeField] private IndexMenu _index;

    public void SetIndex(int i)
    {
        _index.Index = i;
    }
}
