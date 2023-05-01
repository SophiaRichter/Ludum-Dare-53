using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public GameObject deathMenuPrefab;
    private CameraMovement cam;
    private Image letter1;
    private Image letter2;
    private Image letter3;
    private Image speedMeter;
    private GameObject deathMenu;

    void Start()
    {
        cam = GetComponentInParent<CameraMovement>();
        Image[] sprites = GameObject.FindGameObjectWithTag("UI").GetComponentsInChildren<Image>();
        letter1 = sprites[1];
        letter2 = sprites[2];   
        letter3 = sprites[3];   
        speedMeter = sprites[4];
    }

    void OnGUI()
    {
        if (cam.GetPlayer().HasLost())
        {
            if (deathMenu == null)
            {
                deathMenu = Instantiate(deathMenuPrefab, new Vector3(550,300,0), Quaternion.identity);
                deathMenu.transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform);
            }
        }
        else if (cam.GetPlayer().health == 1)
        {
            letter1.color = letter1.color.WithAlpha(1);
            letter2.color = letter2.color.WithAlpha(0);
            letter3.color = letter3.color.WithAlpha(0);
        }
        else if (cam.GetPlayer().health == 2)
        {
            letter1.color = letter1.color.WithAlpha(1);
            letter2.color = letter2.color.WithAlpha(1);
            letter3.color = letter3.color.WithAlpha(0);
        }
        else if (cam.GetPlayer().health == 3)
        {
            letter1.color = letter1.color.WithAlpha(1);
            letter2.color = letter2.color.WithAlpha(1);
            letter3.color = letter3.color.WithAlpha(1);
        }

        speedMeter.fillAmount = cam.speed / cam.maxSpeedPlayer;
        if (cam.GetPlayer().OnHorse())
        {
            speedMeter.fillAmount = cam.speed / cam.maxSpeedHorse;
        }
    }

}
