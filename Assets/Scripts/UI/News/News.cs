using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "News")]
public class News : ScriptableObject
{
    [SerializeField] private string _info;
    public string Info
    {
        get 
        {
            return _info;
        }
    }
    [SerializeField] private string _date;
    public string Date
    {
        get
        {

            return _date;
        }
    }
    
    [SerializeField] private Sprite _photo;
    public Sprite Photo
    {
        get
        {
            return _photo;
        }
    }



}
