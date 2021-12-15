using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anim;//保护于父子关系中使用
    //protected AudioSource dateAudio;




    protected virtual void Start()
    {
        //dateAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }
    public void Death()
    {
        
        Destroy(gameObject);
    }
    public void JumpOn()
    {
        anim.SetTrigger("death");
        //dateAudio.Play();
        SoundManager.intstatic.DateAudio();
    }
  


}