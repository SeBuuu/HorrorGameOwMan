using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningObject : MonoBehaviour
{
    public Transform _camera;
    public LayerMask obiekty;
    public Animator animator;
    public bool Opening = false;
    public bool isLocked;
    public string objectLock;
    public bool mozeOtworzyć;
    public Transform obiekt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
        RaycastHit hitinfo;
        
       
        if(Physics.Raycast(_camera.position,_camera.TransformDirection(Vector3.forward),out hitinfo,3f,obiekty) && Input.GetButtonDown("E") && Opening == false)
        {
            if(isLocked == true && mozeOtworzyć == true)
            {
                animator.SetTrigger("Tr_Open");
                Opening = true;
                ExampleCoroutine();

            }
            else if (isLocked == true && mozeOtworzyć == false)
            {

            }
            else
            {
                animator.SetTrigger("Tr_Open");
                Opening = true;
                ExampleCoroutine();
            }

        }
        else if (Physics.Raycast(_camera.position,_camera.TransformDirection(Vector3.forward),out hitinfo,3f,obiekty) && Input.GetButtonDown("E") && Opening == true)
        {
            animator.SetTrigger("Tr_Close");
            Opening = false;
            ExampleCoroutine();
        }
        if(obiekt.name == $"{hitinfo.collider.gameObject.name}Lock" )
        {
            mozeOtworzyć = true;
        }
        else
        {
            mozeOtworzyć = false;
        }
         animator = hitinfo.collider.gameObject.GetComponent<Animator>();
    }
    
}
