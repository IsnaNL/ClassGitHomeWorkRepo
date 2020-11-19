using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMovement : MonoBehaviour
{
    private float HorInput;
    public float Fuel;
    public Vector2 Velocity;
    private float gravity;
    public float fuelUsage;
    public float liftForce;
    public float MaxVelocity;
    public float fillRate;
    public float horMovementSpeed;
    public LayerMask groundLayerMask;
    public float groundCheckDistance;


    void Update()
    {
        Velocity = Vector2.ClampMagnitude(Velocity, MaxVelocity);
        if (!Isgrounded())
        {
            Velocity.y -= gravity * Time.deltaTime;
           
        }
        HorInput = Input.GetAxis("Horizontal");
        if (HorInput != 0)
        {
            Velocity.x += HorInput * horMovementSpeed * Time.deltaTime;
        }
        if (Input.GetButton("Jump"))
        {
            if(Fuel > 0)
            {
                Fuel -= fuelUsage * Time.deltaTime;
                Velocity.y += liftForce * Time.deltaTime;
            }
        }
        else
        {
            if(Fuel < 100)
            {
                Fuel += fillRate * Time.deltaTime;
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Velocity * Time.fixedDeltaTime);
    }
    public bool Isgrounded()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
        if (hitGround)
        {
            Velocity.y *= 0.99f;
            gravity = 0;
            return true;
        }
        else
        {
            gravity = 5;
            return false;
        }
    }
}
