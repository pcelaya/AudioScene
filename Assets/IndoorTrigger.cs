using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class IndoorTrigger : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot indoorSnapshot;
    [SerializeField] private AudioMixerSnapshot outdoorSnapshot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            indoorSnapshot.TransitionTo(0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outdoorSnapshot.TransitionTo(0.1f);
        }
    }
}
