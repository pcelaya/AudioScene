using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{

    public GameObject UI;

    object OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            //GameObject.Find("UIInteract").SetActive(true);
            UI.SetActive(true);
            //audioSource.Play();
        }
        return null;
    }

    object OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            UI.SetActive(false);
            //audioSource.Stop();
        }
        return null;
    }
}
