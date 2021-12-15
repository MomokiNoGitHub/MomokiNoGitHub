using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : Enemy
{
    private Rigidbody2D rb;
    //private Animator anim;
    private Collider2D Coll;
    private bool Faceleft = true;//判断是否在向左移动

    public Transform leftpoint, rightpoint;
    public float speed, jumpforce;
    
    public LayerMask Ground;



   protected override void Start()
    {

        base.Start();
        rb = GetComponent<Rigidbody2D>();
     
        transform.DetachChildren();//分离子项目
      // anim = GetComponent<Animator>();
        Coll = GetComponent<Collider2D>();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SwitchAnim();




    }
    private void Movement()
    {
        if (Coll.IsTouchingLayers(Ground))
        {
            anim.SetBool("jumping", true);
            if (Faceleft)
            {
                if (transform.position.x < leftpoint.position.x)
                {
                    rb.velocity = new Vector2(speed, jumpforce);
                    transform.localScale = new Vector2(-1, 1);//改变方向
                                                              //Transform.LocaLScale改变缩放
                    Faceleft = false;
                }
                else
                {
                    rb.velocity = new Vector2(-speed, jumpforce);
                }
            }
            else
            {
                if (transform.position.x > rightpoint.position.x)
                {
                    rb.velocity = new Vector2(-speed, jumpforce);
                    transform.localScale = new Vector2(1, 1);
                    Faceleft = true;
                }
                else
                {
                    rb.velocity = new Vector2(speed, jumpforce);
                }
            }
        }

    }

    void SwitchAnim()
    {
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.1f)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        if (Coll.IsTouchingLayers(Ground) && anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
            

        }
           

    }
    
}

   

