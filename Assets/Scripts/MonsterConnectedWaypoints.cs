using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MonsterConnectedWaypoints : MonsterWaypoints
    {
        [SerializeField]
        protected float connectivityRadius = 50f;

        List<MonsterConnectedWaypoints> connections;

        // Start is called before the first frame update
        public void Start()
        {
            //Grab all waypoint objects in scene.
            GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");

            //Create a list of waypoints I can refer to later.
            connections = new List<MonsterConnectedWaypoints>();

            //Check if they're a connected waypoint.
            for (int i = 0; i < allWaypoints.Length; i++)
            {
                MonsterConnectedWaypoints nextWaypoint = allWaypoints[i].GetComponent<MonsterConnectedWaypoints>();

                //i.e. we found a waypoint.
                if (nextWaypoint != null)
                {
                    if (Vector3.Distance(this.transform.position, nextWaypoint.transform.position) <= connectivityRadius && nextWaypoint != this)
                    {
                        connections.Add(nextWaypoint);
                    }
                }
            }
        }

        // Update is called once per frame
        public void Update()
        {

        }

        public override void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, connectivityRadius);
        }

        public MonsterConnectedWaypoints NextWaypoint(MonsterConnectedWaypoints previousWaypoint)
        {
            if (connections.Count == 0)
            {
                //No waypoints? Return null and complain.
                Debug.LogError("Insufficient waypoint count.");
                return null;
            }
            else if (connections.Count == 1 && connections.Contains(previousWaypoint))
            {
                //Only one waypoint and it's the previous one? Just use that.
                return previousWaypoint;
            }
            else
            {
                MonsterConnectedWaypoints nextWaypoint;
                int nextIndex = 0;

                do
                {
                    nextIndex = UnityEngine.Random.Range(0, connections.Count);
                    nextWaypoint = connections[nextIndex];

                } while (nextWaypoint == previousWaypoint);

                return nextWaypoint;
            }
        }
    }

}