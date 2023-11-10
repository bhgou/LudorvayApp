using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChangeInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _info;
    [SerializeField] private Image _sprite;
    [SerializeField] private ScriptableInfo[] _infoScriptable;
    [SerializeField] private int index = 0;
    [SerializeField] private Animator _anim;
    private void Start()
    {
        SetInfo();
    }

    private void SetInfo()
    {
        _nameText.text = _infoScriptable[index].Name;
        _info.text = _infoScriptable[index].Info;
        _sprite.sprite = _infoScriptable[index].Image;
    }
    public void Next()
    {
        if(index >= _infoScriptable.Length-1)
        {
            index = _infoScriptable.Length - 1;
        }
        else
        {
            index++;
            _anim.Play("Next");
        }
    }
    public void Prevous()
    {
        if (index <= 0)
        {
            index = 0;
        }   
        else
        {
            index--;
            _anim.Play("Back");
        }
    }
}
