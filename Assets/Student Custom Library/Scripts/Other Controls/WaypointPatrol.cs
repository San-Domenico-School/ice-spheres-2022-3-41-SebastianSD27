using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    private GameObject[] waypoints;
    private NavMeshAgent navMeshAgent;
    private int waypointIndex;

    // Start is called before the first frame update
    private void Start()
    {
        waypoints = GameManager.Instance.waypoints;
        navMeshAgent = GameObject.Find("IceSphere_Level2").GetComponent<NavMeshAgent>();
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
            return;

        navMeshAgent.SetDestination(waypoints[waypointIndex].transform.position);
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
        
    }
}
