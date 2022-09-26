using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 cameraDistance;

    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + cameraDistance;
        transform.LookAt(player);
    }
}
