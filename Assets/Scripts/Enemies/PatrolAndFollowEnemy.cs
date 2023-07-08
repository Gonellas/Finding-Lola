using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAndFollowEnemy : MonoBehaviour
{
    public Transform target; 
    public int speed;
    bool playerSpotted;
    public Transform[] waypointsArray; 
    public List<Transform> waypointsList; 
    int waypointIndex = 0; 
    int directionWaypoint = 1; 

    void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerMove>().transform;
        }
    }

    void Update()
    {
        if (target == null) return;

        if (playerSpotted) followPlayerRotationSpottedPoint();
        else Patrol();
    }

    void Patrol()
    {
        if(waypointsArray.Length <=0) return; 

        transform.position = Vector3.MoveTowards(transform.position, waypointsArray[waypointIndex].position, speed * Time.deltaTime); 
      
        if(Vector3.Distance(transform.position, waypointsArray[waypointIndex].position) < 0.5f) 
        {
            waypointIndex++;

            if (waypointIndex >=waypointsArray.Length) 
            {
                waypointIndex = 0;
            }
        }
    }

    void followPlayerRotationSpottedPoint()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction); 
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        direction = direction.normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void PlayerHasBeenSeen()
    {
        if (!playerSpotted) playerSpotted = true;
        else playerSpotted = false;
    }
}
