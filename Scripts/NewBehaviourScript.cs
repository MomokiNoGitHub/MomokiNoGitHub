using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
     

    public float speed,jumpforce;
    public LayerMask gronud;
    public int cherry,gem;
    public float hp;
    public Collider2D Discoll;
    public Collider2D coll;
    public Joystick joystick;

    public Text CherryNum,hpNum,gemNum;
    public Transform groundCheck,cellingChecks;
   // public AudioSource JumpAuido,huatAuido,cherryAuido;


    public bool isGround, isJump;
    public bool isHort;

   

    bool jumpPressed,crouchPressed;
    int jumpCount;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        anim = GetComponent<Animator>();

        
    }
   void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }

        Crouch();
    }

    private void FixedUpdate()
    {
        if (!isHort)
        {
            Movement();
        }
       
        SwitchAnim();
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, gronud);
        Jump();
        


    }
    void Movement()
    {
        float horizontalMove = joystick.Horizontal;//Input.GetAxisRaw("Horizontal");键盘控制输入
       
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        anim.SetFloat("runing", Mathf.Abs(horizontalMove));//平移动画

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
           
        }
        ;
    }



    void Jump()
    {
        
        if (isGround && !isHort)
        {
            jumpCount = 2;
            isJump = false;
            
        }
        if (jumpPressed && isGround && !isHort)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpCount--;
            jumpPressed = false;
            SoundManager.intstatic.jumpAuido();

        }
        else if (jumpPressed && jumpCount > 0 && !isGround && !isHort)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpCount--;
            jumpPressed = false;
            SoundManager.intstatic.jumpAuido();

        }
        

        



    }
    void Crouch()
    {
        if (!Physics2D.OverlapCircle(cellingChecks.position, 0.2f, gronud))
        {
            if (Input.GetButton("Crouch"))
            {
                Discoll.enabled = true;
                coll.enabled = false;
                anim.SetBool("crouching", true);
            }
            else
            {
                anim.SetBool("crouching", false);
                Discoll.enabled = false;
                coll.enabled = true;
            }
        }
    }



    void SwitchAnim()//动画
    {
        anim.SetFloat("jumping", Mathf.Abs(rb.velocity.x));
        if(rb.velocity.y < 0.1f && !coll.IsTouchingLayers(gronud))
        {
            anim.SetBool("falling",true);
        }
        if (isGround)
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
            anim.SetBool("falling", false);

        }

        if (isHort)
        {
            anim.SetBool("hurt", true);

          

            

            if (Mathf.Abs(rb.velocity.x) < 0.1f)//受伤退出
            {
                isHort = false;
                anim.SetBool("hurt", false);
                anim.SetBool("idel", true);
               


            }
        }
        else if (!isGround && rb.velocity.y > 0)//判断落地
        {

            anim.SetBool("jumping", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);

        }
     

    }
    private void OnTriggerEnter2D(Collider2D collision)//碰撞到另一个碰撞体触发效果
    {
        article Article = collision.gameObject.GetComponent<article>();
        
        if (collision.tag == "enemy")
        {
            SoundManager.intstatic.CherryAuido();
            //cherryAuido.Play();
            /* Destroy(collision.gameObject);//消除对象*/
            Article.Cherry();

            cherry += 1;
            CherryNum.text = cherry.ToString();
        }
        if (collision.tag == "Daethlink" || hp == 0)
        {
            Invoke(nameof(Restart), 0.2f);//延迟运行

        }
        
        if (collision.tag == "Enem" )
        {
            genno Genno = collision.gameObject.GetComponent<genno>();
            gem += 1;
            gemNum.text = gem.ToString();
            Genno.gemHansu();
            SoundManager.intstatic.CherryAuido();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//消除敌人 
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();//调用Enmy父级中子级中的全部组件
        if (collision.gameObject.tag == "Enemy" )
        {
            if (anim.GetBool("falling"))
            {
               
                //estroy(collision.gameObject);销毁组件只能用在该类，不能调用其它类
                enemy.JumpOn();//调用其它类来销毁组件
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                jumpCount--;
                jumpPressed = false;
            } 
            else if (transform.position.x < collision.gameObject.transform.position.x)//受伤
            {
                rb.velocity = new Vector2(-4, rb.velocity.y);
                //huatAuido.Play();
                SoundManager.intstatic.HuatAuido();
                isHort = true;
                hp -= 1;
                hpNum.text = hp.ToString();
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(4, rb.velocity.y);
                //huatAuido.Play();
                SoundManager.intstatic.HuatAuido();
                isHort = true;
                hp -= 1;
                hpNum.text = hp.ToString();
            }
        }
        if (hp == 0)
        {
            Restart();

        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//重启当前关卡需要using UnityEngine.SceneManagement;工具箱（获取当前关卡名字）
    }

}



