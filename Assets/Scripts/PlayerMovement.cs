using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Move();
    }

 

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        rb.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
    }
       
}
