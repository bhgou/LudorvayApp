using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScriptable : MonoBehaviour
{
    public GuideScriptable _guide;
    [SerializeField] private Guide _info;

    private void OnMouseDown()
    {
        _info.gameObject.SetActive(true);
        _info._guide = _guide;
    }

}
