using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossum : Enemy
{
    private Rigidbody2D rb;
    //private Animator anim;
    private Collider2D Coll;
    private bool Faceleft = true;//判断是否在向左移动

    public Transform leftpoint, rightpoint;
    public float speed;
    
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        transform.DetachChildren();//分离子项目
                                   
        Coll = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {


       
                    
            if (Faceleft)
            {
                
                if (transform.position.x < leftpoint.position.x)
                {
                    
                    transform.localScale = new Vector2(-1, 1);//改变方向
                                                              //Transform.LocaLScale改变缩放
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    Faceleft = false;//面向左关闭
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
            }
            else
            {
                if (transform.position.x > rightpoint.position.x)
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    transform.localScale = new Vector2(1, 1);
                    Faceleft = true;
                }
                else
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
            }
        }


    
}
