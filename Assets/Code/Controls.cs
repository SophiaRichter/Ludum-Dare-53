using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Controls : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float jumpSpeed = 7.0f;

    private bool isGrounded;
    private Rigidbody rb;
    private CameraMovement cam;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInParent<CameraMovement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float newPosition = transform.position.x + (horizontalInput * horizontalSpeed * Time.deltaTime);

        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (cam.speed > 0)
        {
            animator.Play("PlayerRun");
            Mathf.Lerp(animator.speed, cam.maxSpeed/100, cam.speed/100);
        }
        else animator.Play("PlayerIdle");

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            cam.speed *= 0.50f;
            Debug.Log("Collision");
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
