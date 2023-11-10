using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    public GameObject[] OutLineScripts = new GameObject[0];
    GameObject player;
    private Camera cam;

    private float cl;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();;
        player = GameObject.Find("Player");
        StartCoroutine(CalculateDistanceToPlayer());
        StartCoroutine(BackGround());
    }

    IEnumerator CalculateDistanceToPlayer()
    {
        while(true)
        {
            if(player.transform.position.y - transform.position.y > 50)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
    
    IEnumerator BackGround()
    {
        
        yield return new WaitForEndOfFrame();
        Mks();
        while(true)
        {
            yield return new WaitForEndOfFrame();
            if(cl != Camera.main.backgroundColor.a)
            {
                Mks();
                break;
            }
        }
        while (true)
        {
            yield return new WaitForSecondsRealtime(6);
            Mks();
        }
    }

    void Mks()
    {
        if(Camera.main.backgroundColor.a == 1)
        {
            for (int i = 0; i<OutLineScripts.Length; i++)
            {
                OutLineScripts[i].transform.GetChild(0).GetComponent<LineRenderer>().startColor = Color.black;
                OutLineScripts[i].transform.GetChild(0).GetComponent<LineRenderer>().endColor = Color.black;
            }
        }
        else
        {
            for (int i = 0; i<OutLineScripts.Length; i++)
            {
                OutLineScripts[i].transform.GetChild(0).GetComponent<LineRenderer>().startColor = Color.white;
                OutLineScripts[i].transform.GetChild(0).GetComponent<LineRenderer>().endColor = Color.white;
            }
        }
        cl =  Camera.main.backgroundColor.a; 
    }
}
