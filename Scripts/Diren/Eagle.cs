using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle :Enemy //子类
{

    private Rigidbody2D rb;
    
    private Collider2D Coll;
    private bool isUp =true;
    private float TopY, BottomY;




    public Transform top, Bottom;
    public float speed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
       
        Coll = GetComponent<Collider2D>();
        transform.DetachChildren();
        TopY = top.position.y;
        BottomY = Bottom.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (isUp)
        {
            rb.velocity = new Vector2(rb.velocity.x,speed);
            if (transform.position.y > TopY)
            {
                isUp = false;
            }
        }
        
        else
        {
            
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                if (transform.position.y < BottomY)
                {
                    isUp = true;
                }
            

        }
        
    }
    


}
