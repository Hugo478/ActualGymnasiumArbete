using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public Transform Origin;
    public float distance = 0.5f;

    private int jumps = 0;
    public bool OnContact(){

        return Physics2D.Raycast(Origin.position, Vector2.down, distance);

    }


    private void Update()
    {
        Debug.Log(OnContact());
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && jumps > 0){
            jumps -= 1;
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    
        if(OnContact() == true){
            jumps  = 1;
        }
}
}
