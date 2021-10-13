using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            MonsterController.playerInVision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MonsterController.playerInVision = false;
        }
    }
}
