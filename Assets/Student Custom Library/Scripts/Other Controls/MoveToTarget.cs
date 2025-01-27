using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveToTarget : MonoBehaviour
{
    //fields
    [SerializeField] private NavMeshAgent navMeshAgent;
    private GameObject target;
    private Rigidbody targetRb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        targetRb = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();   
    }
    //ice spheres move towards target (player)
    private void MoveTowardsTarget()
    {
        navMeshAgent.SetDestination(targetRb.transform.position);
    }
}
