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
    [SerializeField] public doorOpen doorOpen;
    [SerializeField] public SzafkaOpen szafkaOpen;
    
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

        if(Physics.Raycast(Camera.position,Camera.TransformDirection(Vector3.forward),out RaycastHit hitinfo,3f,drzwi) && czyOtwiera == false && Input.GetButtonDown("E"))
        {
            doorOpen.dorOpen();
            czyOtwiera = true;
        }
        else if (Physics.Raycast(Camera.position,Camera.TransformDirection(Vector3.forward),out hitinfo,3f,drzwi) && czyOtwiera == true && Input.GetButtonDown("E"))
        {
            doorOpen.dorClose();
            czyOtwiera = false;
        }
        if(Physics.Raycast(Camera.position,Camera.TransformDirection(Vector3.forward),out RaycastHit hitinfoszafka,3f,szafka) && czyOtwieraszafke == false && Input.GetButtonDown("E"))
        {
            szafkaOpen.szafkaOpen();
            czyOtwieraszafke = true;
        }
        else if (Physics.Raycast(Camera.position,Camera.TransformDirection(Vector3.forward),out hitinfoszafka,3f,szafka) && czyOtwieraszafke == true && Input.GetButtonDown("E"))
        {
            szafkaOpen.szafkaClose();
            czyOtwieraszafke = false;
        }
        
        
        Debug.DrawRay(Camera.position,Camera.TransformDirection(Vector3.forward) * hitinfo.distance,Color.green);


    }
}
