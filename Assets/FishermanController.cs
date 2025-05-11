using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishermanController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> dialogue = new List<AudioClip>();

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.clip = dialogue[Random.Range(0, dialogue.Count)];
        }
    }

    object OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            audioSource.clip = dialogue[Random.Range(0, dialogue.Count)];
        }
        return null;
    }
}
