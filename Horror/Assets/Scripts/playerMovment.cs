using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public CharacterController characterController;
    
    [SerializeField] public Transform groundCheck;
    [SerializeField] public Transform Camera;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float gravity = -10;
    [SerializeField] public float groundDistance = -0.4f;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] public LayerMask drzwi;
    [SerializeField] public LayerMask szafka;

    [SerializeField] Vector3 velocity;
    [SerializeField] bool isGrounded;
    [SerializeField] bool czyOtwiera = false;
    [SerializeField] bool czyOtwieraszafke = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectScale = transform.localScale;
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * moveSpeed * Time.deltaTime);

        velocity.y += gravity;

        characterController.Move(velocity * Time.deltaTime);

        if(Input.GetButton("Fire3"))
        {
            moveSpeed = 9;
        }
        else if (Input.GetButton("Fire1"))
        {
            moveSpeed = 3;
            transform.localScale = new Vector3(objectScale.x,  objectScale.y = 0.5f, objectScale.z);
        }
        else
        {
            transform.localScale = new Vector3(objectScale.x,  objectScale.y = 1, objectScale.z);
            moveSpeed = 6;
        }

       

    }
}
