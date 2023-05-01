using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class CameraMovement : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeedPlayer = 100f;
    public float maxSpeedHorse= 120f;
    public int levelLength = 5;

    public GameObject baseObstacle;
    private GameObject lastObject;
    public GameObject castle;
    private int count;

    private Player player = new();

    void Start()
    {
        GameObject newObstacle = Instantiate(baseObstacle, new Vector3(0,0,150), Quaternion.identity);
        lastObject = newObstacle;
    }

    void Update()
    {
        if (player.HasAlreadyWon() || player.HasLost()) return;
        float verticalInput = Mathf.Max(Input.GetAxis("Vertical"), 0);

        if (speed < maxSpeedPlayer)
        { 
            speed += verticalInput * 10 * Time.deltaTime;
        }
        if (speed < maxSpeedHorse && player.OnHorse())
        {
            speed += verticalInput * 15 * Time.deltaTime;
        }

        transform.position += new Vector3(0, 0, 1) * (speed * Time.deltaTime);

        if (transform.position.z - lastObject.transform.position.z > 20)
        {
            Debug.Log("Loading new area");
            if (count < levelLength)
            {
                GameObject newObstacle = Instantiate(baseObstacle, new Vector3(lastObject.transform.position.x, lastObject.transform.position.y, lastObject.transform.position.z + 150), Quaternion.identity);
                lastObject = newObstacle;
                count++;
            }
            else
            {
                GameObject newObstacle = Instantiate(castle, new Vector3(lastObject.transform.position.x, lastObject.transform.position.y, lastObject.transform.position.z + 150), Quaternion.identity);
                lastObject = newObstacle;
            }   
        }
    }

    public Player GetPlayer()
    {
        return player;
    }
}
