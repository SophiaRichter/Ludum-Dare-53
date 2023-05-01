using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] items;

    void Start()
    {
        GameObject[] itemMarkers = GameObject.FindGameObjectsWithTag("ItemMarker");
        foreach (GameObject g in itemMarkers)
        {
            int randIndex = Random.Range(0, items.Length);
            Instantiate(items[randIndex], g.transform.position, Quaternion.identity, gameObject.transform);
            g.tag = "Marked";
        }
    }

}
