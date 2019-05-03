using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class MonsterConnectedPatrol : MonoBehaviour
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

        //Private variables for base behavior.
        NavMeshAgent navMeshAgent;
        MonsterConnectedWaypoints currentWaypoint;
        MonsterConnectedWaypoints previousWaypoint;

        bool traveling;
        bool waiting;
        float waitTimer;
        int waypointsVisited;

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
                if (currentWaypoint == null)
                {
                    GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

                    if (allWaypoints.Length > 0)
                    {
                        while (currentWaypoint == null)
                        {
                            int random = UnityEngine.Random.Range(0, allWaypoints.Length);
                            MonsterConnectedWaypoints startingWaypoint = allWaypoints[random].GetComponent<MonsterConnectedWaypoints>();

                            //i.e. we found a waypoint.
                            if (startingWaypoint != null)
                            {
                                currentWaypoint = startingWaypoint;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("Failed to find any waypoints for use in the scene.");
                    }
                }

                SetDestination();
            }
        }

        // Update is called once per frame
        void Update()
        {
            //Check if we're close to the destination.
            if (traveling && navMeshAgent.remainingDistance <= 1.0f)
            {
                traveling = false;
                waypointsVisited++;

                if (patrolWaiting)
                {
                    waiting = true;
                    waitTimer = 0f;
                }
                else
                {
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
                    
                    SetDestination();
                }
            }
        }

        private void SetDestination()
        {
            if (waypointsVisited > 0)
            {
                MonsterConnectedWaypoints nextWaypoint = currentWaypoint.NextWaypoint(previousWaypoint);
                previousWaypoint = currentWaypoint;
                currentWaypoint = nextWaypoint;
            }

            Vector3 targetVector = currentWaypoint.transform.position;
            navMeshAgent.SetDestination(targetVector);
            traveling = true;
        }
    }
}