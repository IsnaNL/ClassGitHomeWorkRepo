using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMovement : MonoBehaviour
{
    private float HorInput;
    public float Fuel;
    public Vector2 Velocity;
    public float gravity;
    public float FuelUsage;
    public float LiftForce;
    public float FillRate;
    public float HorMovementSpeed;
    public LayerMask GroundLayerMask;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Isgrounded())
        {
            Velocity.y -= gravity * Time.deltaTime;

        }
        HorInput = Input.GetAxis("Horizontal");
        if (HorInput != 0)
        {
            Velocity.x += HorInput * HorMovementSpeed * Time.deltaTime;
        }
        if (Input.GetButton("Jump"))
        {
            if(Fuel > 0)
            {
                Fuel -= FuelUsage * Time.deltaTime;
                Velocity.y += LiftForce * Time.deltaTime;
            }
           

        }
        else
        {
            if(Fuel < 100)
            {
                Fuel += FillRate * Time.deltaTime;
            }
        }
    }
    private void FixedUpdate()
    {
        
        
       
        transform.Translate(Velocity * Time.fixedDeltaTime);
    }
    public bool Isgrounded()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down, 2, GroundLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 2, Color.red);
        if (hitGround)
        {
            Velocity *= 0.5f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
