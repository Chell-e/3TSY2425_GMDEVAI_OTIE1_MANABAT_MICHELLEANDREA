using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    //public GameObject[] waypoints;

    public UnityStandardAssets.Utility.WaypointCircuit circuit;
    public int currentWaypointIndex = 0;

    private float speed = 15f;
    private float rotationSpeed = 3f;
    private float accuracy = 1f;
    void Start()
    {
        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    void LateUpdate()
    {
        if (circuit.Waypoints.Length == 0) return;

        GameObject currentWayPoint = circuit.Waypoints[currentWaypointIndex].gameObject;

        Vector3 lookAtWaypoint = new Vector3(currentWayPoint.transform.position.x, 
                                            this.transform.position.y, 
                                            currentWayPoint.transform.position.z);

        Vector3 direction = lookAtWaypoint - this.transform.position;

        if (direction.magnitude < 1.0f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= circuit.Waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                                Quaternion.LookRotation(direction), 
                                                Time.deltaTime * rotationSpeed);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
