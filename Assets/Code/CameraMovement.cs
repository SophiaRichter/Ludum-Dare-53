using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 120f;

    public GameObject baseObstacle;
    private GameObject lastObject;

    void Start()
    {

    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (speed < maxSpeed)
        { 
            speed += verticalInput * 10 * Time.deltaTime;
        }
        transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;

        if (transform.position.z %100  == 0)
        { 
            
        }

    }
}
