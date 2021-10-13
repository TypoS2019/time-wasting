using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MonsterController : MonoBehaviour
{
    public List<GameObject> waypoints;


    public NavMeshAgent agent;

    private bool start = true;
    private int counter = 0;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        start = true;
    }

    void Start()
    {
        StartCoroutine(Patrol(waypoints[0].transform.position));
    }

    IEnumerator Patrol(Vector3 target)
    {
        agent.SetDestination(target);
        while (true)
        {
            if()

            if (Vector3.Distance(target, transform.position) <= 1f)
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

    void OnTrigerEnter()
    {
        
    }

}