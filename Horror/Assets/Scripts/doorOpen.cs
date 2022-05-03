using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    bool czyOtwarte;
    public Animator animator;
    void Start()
    {
        animator = animator.GetComponent<Animator>();
        czyOtwarte = false;
    }
   
   public void doorOpening()
   {
    if(!czyOtwarte)
    {
        animator.Play("Door",0,0.0f);
        czyOtwarte = true;
    }
    else
    {
        animator.Play("DoorClose,0,0.0f");
        czyOtwarte = false;
    }
   }
}
