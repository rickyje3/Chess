using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace AvoiderPlugin
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Avoider: MonoBehaviour
    {
        //public Transform movePosition;
        public NavMeshAgent agent;
        public Transform avoidee;
        public float range = 10f;
        public bool showGizmos = true;
        private PoissonDiscSampler sampler;
        //private bool isAvoiding = false;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            sampler = new PoissonDiscSampler(range, range, 1f); // 1f is the minimum distance between points
        }

        private void Update()
        {
            //agent.destination = GameObject.FindWithTag("Player").transform.position;

            agent = GetComponent<NavMeshAgent>();

            //Check distance to avoidee
            float distance = Vector3.Distance(transform.position, avoidee.position);

            if (distance <= range)
            {
                AvoidAvoidee();
            }
        }

        void AvoidAvoidee()
        {
            //if (isAvoiding) return;

            //Check visibility of avoidee
            if (CanAvoideeSeeMe())
            {
                var candidateSpots = GenerateHidingSpots();

                //Find closest valid spot
                Vector3 bestSpot = FindBestHidingSpot(candidateSpots);

                //Move to new spot
                if (bestSpot != Vector3.zero)
                {
                    agent.SetDestination(bestSpot);
                    //isAvoiding = true;
                }
            }
        }

        bool CanAvoideeSeeMe()
        {
            RaycastHit hit;
            Vector3 directionToAvoidee = avoidee.position - transform.position;

            //Raycast to check 
            if (Physics.Raycast(transform.position, directionToAvoidee, out hit, range))
            {
                //if hit object is avoidee, it can see player
                if (hit.transform == avoidee)
                {
                    return true;
                }
            }
            return false;
        }

        Vector3 FindBestHidingSpot(Vector3[] candidateSpots)
        {
            Vector3 bestSpot = Vector3.zero;
            float minDistance = Mathf.Infinity;

            foreach (var spot in candidateSpots)
            {
                float dist = Vector3.Distance(transform.position, spot);
                if (dist < minDistance)
                {
                    bestSpot = spot;
                    minDistance = dist;
                }
            }
            return bestSpot;
        }

        Vector3[] GenerateHidingSpots()
        {
            //use poissondiscsampler to generate hiding points
            var hidingSpots = new List<Vector3>();
            foreach (Vector2 sample in sampler.Samples())
            {
                Vector3 candidatePoint = new Vector3(sample.x, transform.position.y, sample.y);

                //Check if avoidee can see the point
                if (!IsPointVisibleToAvoidee(candidatePoint))
                {
                    hidingSpots.Add(candidatePoint);
                }

                if (showGizmos)
                {
                    Debug.DrawLine(transform.position, candidatePoint, Color.red, 0.5f);
                }
            }

            return hidingSpots.ToArray();
        }

        bool IsPointVisibleToAvoidee(Vector3 point)
        {
            RaycastHit hit;
            Vector3 direction = avoidee.position - point;

            //Raycast from point to avoidee to check visibility
            if (Physics.Raycast(point, direction, out hit, range))
            {
                //if something other than avoidee is hit, hide point
                if (hit.transform != avoidee)
                {
                    return false;
                }
            }
            return true;
        }

        // Optionally draw Gizmos in the editor
        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, range); // Visualize the range
            }
        }
    }
}
