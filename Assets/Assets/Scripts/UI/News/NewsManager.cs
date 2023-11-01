using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NewsManager : MonoBehaviour
{
    [SerializeField] private News _news;
    [SerializeField] private TMP_Text _info;
    [SerializeField] private TMP_Text _date;
    [SerializeField] private Image _photo;

    private void Start()
    {
        _info.text = _news.Info;
        _date.text = _news.Date;
        _photo.sprite = _news.Photo;

    }
}
