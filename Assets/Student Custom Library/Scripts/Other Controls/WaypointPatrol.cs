using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/******************************************************
 * Attached to IceSphere
 * Move IceSpheres through waypoints
 * 
 * Sebastian Balakier
 * 2/14/2025, Version 1.0
 ******************************************************/

public class WaypointPatrol : MonoBehaviour
{
    private GameObject[] waypoints;
    private NavMeshAgent navMeshAgent;
    private int waypointIndex;

    // Start is called before the first frame update
    private void Start()
    {
        waypoints = GameManager.Instance.waypoints;
        navMeshAgent = GetComponent<NavMeshAgent>();
        waypointIndex = Random.Range(0, waypoints.Length);
    }

    // Update is called once per frame
    private void Update()
    {
        MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        if (navMeshAgent.remainingDistance < 0.1)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[waypointIndex].transform.position);
            Debug.Log("Moving to waypoint");
        }
    }
}

