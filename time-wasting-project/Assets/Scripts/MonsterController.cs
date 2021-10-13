using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MonsterController : MonoBehaviour
{
    public List<GameObject> waypoints;

    public GameObject player;
    public NavMeshAgent agent;
    public GameObject visionField;

    public float stopChaseDistance;

    public static bool playerInVision;

    private Transform playerTransform;
    private bool start = true;
    private int counter = 0;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        start = true;
        playerInVision = false;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        StartCoroutine(Patrol(waypoints[0].transform.position));
    }

    IEnumerator Patrol(Vector3 target)
    {
        agent.SetDestination(target);
        while (true)
        {
            if (playerInVision)
            {
                StartCoroutine(Chasing());
                yield break;
            }

            if (Vector3.Distance(target, transform.position) <= 1f)
            {
                StartCoroutine(Patrol(NewTarget()));
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator Chasing()
    {
        while (true)
        {
            agent.SetDestination(playerTransform.position);
            if (Vector3.Distance(playerTransform.position, transform.position) <= stopChaseDistance)
            {
                StartCoroutine(Patrol(NewTarget()));
                yield break;
            }
            yield return null;
        }
    }

    Vector3 NewTarget()
    {
        counter++;

        if(counter == waypoints.Count)
        {
            counter = 0;
        }

        return waypoints[counter].transform.position;
    }

}