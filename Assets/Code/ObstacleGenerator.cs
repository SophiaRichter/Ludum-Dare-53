using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacles;

    void Start()
    {
        GameObject[] obstacleMarkers = GameObject.FindGameObjectsWithTag("ObstacleMarker");
        foreach (GameObject g in obstacleMarkers)
        {
            int randIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randIndex], g.transform.position, Quaternion.identity, gameObject.transform);
            g.tag = "Marked";
        }
    }

    void Update()
    {
        
    }
}
