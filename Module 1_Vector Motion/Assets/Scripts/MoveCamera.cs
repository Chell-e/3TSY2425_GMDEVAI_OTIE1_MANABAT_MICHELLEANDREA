using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    void Start()
    {
        
    }

    void Update()
    {
        // always move with the camera position (attached to the player)
        transform.position = cameraPosition.position;
    }
}
