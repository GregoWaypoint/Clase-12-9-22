using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //public Vector3 startPosition;
    public float Speed;

    Vector3 movementDirection;

    void Start()
    {
       // transform.position = startPosition;
    }

    
    void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal")* Time.deltaTime*Speed;
        movementDirection.z = Input.GetAxis("Vertical")*Time.deltaTime*Speed;
        transform.Translate(movementDirection);

        /*if (Input.GetKey(KeyCode.A))
        {
            movementDirection = new Vector3(-Speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection = new Vector3(Speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection = new Vector3(0f, 0f, Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDirection = new Vector3(0f, 0f, -Speed * Time.deltaTime);
        }*/
        
    }
}
