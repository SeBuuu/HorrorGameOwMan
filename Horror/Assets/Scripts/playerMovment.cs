using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    public CharacterController characterController;
    
    public Transform groundCheck;
    public float moveSpeed;
    public float gravity = -10;
    public float groundDistance = -0.4f;
    public LayerMask groundMask;
    public LayerMask drzwi;

    Vector3 velocity;
    bool isGrounded;
    bool czyOtwiera;
    public doorOpen doorOpen;
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
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out RaycastHit hit,4f,drzwi) && Input.GetButtonDown("E"))
        {
            doorOpen.doorOpening();
            
        }
        
        


    }
}
