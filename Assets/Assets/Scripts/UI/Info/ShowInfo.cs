using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    [SerializeField] private Animator _animation;
    private bool _open = false;

    public void ChangeState()
    {
        _open = !_open;
        _animation.SetBool("move", _open);
    }
}
