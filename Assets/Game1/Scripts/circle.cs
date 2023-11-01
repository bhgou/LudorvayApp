using UnityEngine;
using System.Collections;

public class circle : MonoBehaviour 
{
    public int size;
    public float radius = 3f;
    LineRenderer lineRenderer;
    void Awake () 
    {       
        lineRenderer = gameObject.GetComponent<LineRenderer>();     
    }

    void Start()
    {      
        Circle();
        
    }



    void Circle()
    {
        Vector3 pos;
        for(int i = 0; i<size;i++)
        {
            
            float angle = radius*2 / (size-(size/20)) *i;
            float x = (radius * Mathf.Cos(angle));
            float y = (radius * Mathf.Sin(angle));
            x += gameObject.transform.position.x;
            y += gameObject.transform.position.y;
            pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
        }
    }
}
