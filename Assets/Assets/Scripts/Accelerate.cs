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
        // ��������� ������ � �������������
        float xMove = Input.acceleration.x; // �������� �� ��� X
        float zMove = Input.acceleration.y; // �������� �� ��� Z (��� 2D ����)
        x.text = xMove.ToString();
        y.text = zMove.ToString();
        // ��������� ��������� �������
        transform.position = new Vector3(xMove, zMove); 
    }
}
