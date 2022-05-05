using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SzafkaOpen : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void szafkaOpen()
    {
        animator.SetTrigger("Tr_Open");
    }
    public void szafkaClose()
    {
        animator.SetTrigger("Tr_Close");
    }

    
}
