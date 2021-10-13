using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{

    private Transform transform;
    private LiftableObject liftableObject;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveShit(LiftableObject shit)
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        LiftableObject temp = other.gameObject.GetComponent<LiftableObject>();
        if (temp != null)
        {
            if (temp.parent == null)
            {
                liftableObject = temp.Pickup(transform);
            }   
        }
    }
}
