using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectLifter : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private float range;
    [SerializeField] private float throwForce;
    private LiftableObject liftableObject;
    
    void OnFire()
    {
        if (liftableObject == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.forward, out hit, range))
            {
                LiftableObject temp = hit.collider.GetComponent<LiftableObject>();
                if (temp != null)
                {
                    liftableObject = temp.Pickup(camera);
                }
            }
        }
        else
        {
            liftableObject.Drop(camera.forward * throwForce);
            liftableObject = null;
        }
    }
}
