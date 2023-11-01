using RTS_Cam;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Debug : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Slider _slider;
    [SerializeField] private RTS_Camera _camera;

    private void Start()
    {
        _slider.maxValue = 50;
        _slider.minValue = 0;
        _slider.value = 10;
    }

    private void Update()
    {
        text.text = _slider.value.ToString();
        _camera.panningSpeed = _slider.value;
    }
}
