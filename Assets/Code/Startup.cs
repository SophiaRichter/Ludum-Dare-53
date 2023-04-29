using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject spawn;

    void Start()
    {
       GameObject instPlayer = Instantiate(playerPrefab, spawn.transform.position, spawn.transform.rotation);
    }

    void Update()
    {
        
    }
}
