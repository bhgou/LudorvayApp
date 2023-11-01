using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] private TMP_Text x;
    [SerializeField] private TMP_Text y;
    void Update()
    {
        // Получение данных с акселерометра
        float xMove = Input.acceleration.x; // Движение по оси X
        float zMove = Input.acceleration.y; // Движение по оси Z (для 2D игры)
        x.text = xMove.ToString();
        y.text = zMove.ToString();
        // Изменение координат объекта
        transform.position = new Vector3(xMove, zMove); 
    }
}
