using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.U2D;

public class Controls : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float jumpSpeed = 7.0f;

    private bool isGrounded = false;
    private Rigidbody rb;
    private CameraMovement cam;
    private const float leftBound = -4f;
    private const float rightBound = 4f;
    private Vector3 resetPoint = new Vector3(0, -0.1f, 3);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInParent<CameraMovement>();
    }

    void Update()
    {
        if (cam.GetPlayer().HasAlreadyWon() || cam.GetPlayer().HasLost()) return;
        float horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x > rightBound) horizontalInput = -1 * MathF.Abs(horizontalInput);
        if (transform.position.x < leftBound) horizontalInput = MathF.Abs(horizontalInput);
        float newPosition = transform.position.x + horizontalInput * horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (Mathf.Abs(transform.localPosition.z) - 3 > 1)
        {
            transform.localPosition = resetPoint;
        }
    }

    public void GetHorse()
    {
        if (!cam.GetPlayer().OnHorse()) cam.GetPlayer().AddHealth(1);

        SpriteRenderer[] sprites = transform.root.GetComponentsInChildren<SpriteRenderer>();

        sprites[0].enabled = false;
        sprites[1].enabled = true;
        cam.GetPlayer().SetHorse(true);
    }

    public void LooseHorse()
    {
        SpriteRenderer[] sprites = transform.root.GetComponentsInChildren<SpriteRenderer>();

        sprites[0].enabled = true;
        sprites[1].enabled = false;
        cam.GetPlayer().SetHorse(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide with:" +collision.gameObject.name + " " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            cam.speed *= 0.10f;
            cam.GetPlayer().RemoveHealth(1);
            if (cam.GetPlayer().OnHorse()) LooseHorse();
            //reset position
            transform.localPosition = resetPoint;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
