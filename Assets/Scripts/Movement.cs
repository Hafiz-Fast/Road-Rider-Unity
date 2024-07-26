using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float acceleration = 1f; 
    [SerializeField] float deceleration = 1f;
    [SerializeField] float maxSpeed = 20f; 
    [SerializeField] SurfaceEffector2D surfaceEffector; 
    private bool isGrounded = true; 
    [SerializeField] float currentSpeed = 0f;
    Rigidbody2D rb2d;
    [SerializeField] float torque = 1f;

    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque);
        }

        if (Input.GetKey(KeyCode.A) && isGrounded)
        {
            // Accelerate the player
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }
        else
        {
            // Decelerate the player to a stop
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }

        // Set the speed of the SurfaceEffector2D
        surfaceEffector.speed = currentSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
