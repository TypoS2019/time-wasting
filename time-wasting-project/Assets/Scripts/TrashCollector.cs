using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TrashCollector : MonoBehaviour
{

    [SerializeField] private AudioClip receiveClip;
    [SerializeField] private AudioClip loopClip;
    
    private Transform transform;
    private LiftableObject liftableObject;

    private AudioSource audioSource;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }
    
    public void GiveShit(LiftableObject shit)
    {
        audioSource.clip = receiveClip;
        audioSource.Play();
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
