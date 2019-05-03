using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSimplePatrol : MonoBehaviour
{
    //Dicates whether the agent waits on each node.
    [SerializeField]
    bool patrolWaiting;

    //The total time we wait at each node.
    [SerializeField]
    float totalWaitTime = 3f;

    //The probability of switching direction.
    [SerializeField]
    float switchProbability = 0.2f;

    //The list of all patrol nodes to visit.
    [SerializeField]
    List<MonsterWaypoints> patrolPoints;

    //Private variables for base behavior.
    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool traveling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.Log("The navmesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if (patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behavior.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check if we're close to the destination.
        if (traveling && navMeshAgent.remainingDistance <= 1.0f)
        {
            traveling = false;

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        //Instead if we're waiting.
        if (waiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= totalWaitTime)
            {
                waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }
        }
    }

    private void SetDestination()
    {
        if (patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
            traveling = true;
        }
    }

    /// <summary>
    /// Selects a new patrol point in the avaialbe list, but
    /// also with a small probability allows for us to move forward or backwards.
    /// </summary>
    private void ChangePatrolPoint()
    {
        if (UnityEngine.Random.Range(0f, 1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }
}
