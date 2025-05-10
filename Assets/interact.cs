using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    // Start is called before the first frame update
    private bool interacted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interacted)
            {
                interacted = false;
                audioSource.Stop();
            }
            else
            {
                interacted = true;
                audioSource.Play();
            }
        }
    }
}
