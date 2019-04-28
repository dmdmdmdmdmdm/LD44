using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    
    public float runSpeed = 2.0f;
    private float multiplierX = 1f;
    private float multiplierY = 1f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if((vertical > 0 && horizontal > 0) || (vertical < 0 && horizontal < 0))
        {
            multiplierX = 1f;
            multiplierY = 0.65f;
        } else
        {
            multiplierX = 1f;
            multiplierY = 1f;
        }
    }

    private void FixedUpdate()
    {
        //body.velocity = new Vector2(horizontal * runSpeed * Time.fixedDeltaTime *multiplier, vertical * runSpeed * Time.fixedDeltaTime * multiplier);
        body.position = new Vector2(body.position.x + horizontal * runSpeed * Time.fixedDeltaTime * multiplierX, body.position.y + vertical * multiplierY * runSpeed * Time.fixedDeltaTime);
    }
}
