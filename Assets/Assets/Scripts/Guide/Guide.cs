using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    public GuideScriptable _guide;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private Image _image;
    [SerializeField] private bool _isPlay;
    [SerializeField] private AudioSource audioSource;
    int index = 0;
    private void Update()
    {
        _text.text = _guide.Info;
        _image.sprite = _guide.Image;
        _textName.text = _guide.Name;
        audioSource.clip = _guide.Audio;
    }

    public void PlaySound()
    {
        if(index == 1)
        {
            audioSource.Stop();
            index = 0;
        }
        else
        {
            audioSource.Play();
            index++;
        }
    }
}
