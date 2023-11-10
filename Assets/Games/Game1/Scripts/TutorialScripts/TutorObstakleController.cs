using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorObstakleController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] obstaclesArray;
    public GameObject CanvasTv;

    int playerDistanceIndex = -1;

    int obstacleCount;
    int obstacleIndex = 0;
    int distanceToNext = 33;

    public Tutor Pl;

    void Start()
    {
        obstacleCount = obstaclesArray.Length;
        SpawnObstacle();
        
        Pl.Texti.Add(Instantiate(CanvasTv, new Vector3(0,10), Quaternion.identity).transform.GetChild(0).GetComponent<TextMeshProUGUI>());
    }

    void Update()
    {
        int playerDistance = (int)(player.transform.position.y / (distanceToNext));

        if(Pl.Texti.Count <=15)
        {
            if (playerDistanceIndex != playerDistance)
            {
                SpawnObstacle();
                playerDistanceIndex = playerDistance;
            }
        }
        
    }

    public void SpawnObstacle()
    {
        int randomInt = Random.Range(0, obstacleCount);
        GameObject newObstacle = Instantiate(obstaclesArray[randomInt], new Vector3(0,10+ obstacleIndex * distanceToNext), Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;
        Pl.Texti.Add(Instantiate(CanvasTv, new Vector3(0,10 + obstacleIndex * 33f), Quaternion.identity).transform.GetChild(0).GetComponent<TextMeshProUGUI>());
        Pl.Bukvi();
    }
}

