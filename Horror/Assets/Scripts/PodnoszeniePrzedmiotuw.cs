using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodnoszeniePrzedmiotuw : MonoBehaviour
{
    public Transform _camera;
    public LayerMask przedmioty;
    public OpeningObject openingObject;
    public Transform obiekty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitinfo;
        if(Physics.Raycast(_camera.position,_camera.TransformDirection(Vector3.forward),out hitinfo,5f,przedmioty) && Input.GetButtonDown("E"))
        {
            openingObject.obiekt = hitinfo.collider.gameObject.GetComponent<Transform>();
            hitinfo.collider.gameObject.transform.position = obiekty.position;
        }
    }
}
