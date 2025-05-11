using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    public GameObject UI;
    [SerializeField] public AudioSource audioSource;
    public bool interacted = false;

    object OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            //GameObject.Find("UIInteract").SetActive(true);
            UI.SetActive(true);
            UI.GetComponent<interact>().GetIntractableObject(gameObject);
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
            UI.GetComponent<interact>().RemoveIntractableObject();
            //audioSource.Stop();
        }
        return null;
    }

    public void PlayAudio()
    {
        audioSource.Play();
        interacted = true;
        StartCoroutine(WaitForAudioToEnd());
    }

    public void StopAudio()
    {
        audioSource.Stop();
        interacted = false;
    }

    private IEnumerator WaitForAudioToEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        interacted = false;
    }

}
