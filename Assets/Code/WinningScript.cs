using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningScript : MonoBehaviour
{
    private CameraMovement cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraMovement>();
    }

    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Win");
            cam.GetPlayer().SetWin(true);
        }
    }

}