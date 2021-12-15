using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genno : MonoBehaviour
{
    private Collider2D coll;
    private Animator Anim;
    
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

 
    void Destoy()
    {
        Destroy(gameObject);
    }
    public void gemHansu()
    {

        Anim.SetTrigger("bck");
        

    }
}
