using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class article : MonoBehaviour
{
    private Collider2D coll;
    private Animator Anim;
    

    void Start()
    {
        Anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

  
   void articleSouji()
    {
        Destroy(gameObject);
    }
   public void Cherry()
    {

        Anim.SetTrigger("feedback");
        
        
    }
   
}


