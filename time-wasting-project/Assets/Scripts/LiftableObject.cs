using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LiftableObject : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    public Transform parent;
    [SerializeField] private TrashCollector owner;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float distance;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (parent != null)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, parent.position + parent.forward * distance, Time.deltaTime * moveSpeed));
            if (parent == owner.transform)
            {
                rb.MovePosition(Vector3.Lerp(transform.position, parent.position + parent.up, Time.deltaTime * moveSpeed));
            }
            else
            {
                rb.MovePosition(Vector3.Lerp(transform.position, parent.position + parent.forward * distance, Time.deltaTime * moveSpeed));
                rb.MoveRotation(Quaternion.Slerp(transform.rotation, parent.rotation, Time.deltaTime * rotateSpeed));
            }
        }
    }

    public LiftableObject Pickup(Transform other)
    {
        if (parent != owner.transform)
        {
            rb.useGravity = false;
            parent = other;
            return this;
        }
        return null;
    }

    public void Drop(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Impulse);
        rb.useGravity = true;
        parent = null;
    }
}
