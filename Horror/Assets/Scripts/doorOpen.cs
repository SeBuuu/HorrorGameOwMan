using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void dorOpen()
    {
        animator.SetTrigger("Tr_Open");
    }
    public void dorClose()
    {
        animator.SetTrigger("Tr_Close");
    }

    
}
