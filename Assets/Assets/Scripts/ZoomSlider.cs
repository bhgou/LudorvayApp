using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _minFov;
    [SerializeField] private float _maxFov;

    private void Start()
    {
        _slider.maxValue = _maxFov;
        _slider.minValue = _minFov;
        _slider.value = _minFov;
    }

    private void Update()
    {
        _camera.orthographicSize = _slider.value;
    }
}
