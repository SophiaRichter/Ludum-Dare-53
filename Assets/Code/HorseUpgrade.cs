using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseUpgrade : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Controls>().GetHorse();
            Destroy(gameObject);
        }
    }
}
