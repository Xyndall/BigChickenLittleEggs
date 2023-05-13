using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpointSpawn;
    private bool AlreadyEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.GetComponent<PlayerCheckpoint>().SetNewCheckpoint(gameObject);
            AlreadyEntered = true;
        }
    }

}
