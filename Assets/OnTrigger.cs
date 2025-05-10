using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;

    object OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger zone!");
            audioSource.Play();
        }
        return null;
    }
}
