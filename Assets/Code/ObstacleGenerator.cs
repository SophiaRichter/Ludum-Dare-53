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
            Quaternion rot = Quaternion.Euler(0, 90f * Random.Range(1, 4), 0);
            Instantiate(obstacles[randIndex], g.transform.position, rot, gameObject.transform);
            g.tag = "Marked";
        }
    }

}
