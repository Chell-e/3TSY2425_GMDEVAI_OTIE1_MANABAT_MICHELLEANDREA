using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollowOwner : MonoBehaviour
{
    public Transform owner;
    public float petSpeed;
    public float rotationSpeed;
    void Start()
    {

    }

    void LateUpdate()
    {
        // looks at the owner while maintaining the pet's y position
        Vector3 lookAtOwner = new Vector3(owner.position.x, 
                                        this.transform.position.y, 
                                        owner.position.z);

        Vector3 direction = lookAtOwner - transform.position;

        // slowly rotates to face the owner
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                        Quaternion.LookRotation(direction), 
                                        Time.deltaTime * rotationSpeed);

        // keeps the pet a certain distance from the owner
        if (Vector3.Distance(lookAtOwner, transform.position) > 1.5)
        {
            transform.Translate(0, 0, petSpeed * Time.deltaTime);
        }
    }
}
