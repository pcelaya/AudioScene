using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject interactedObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactedObject == null)
            {
                return;
            }
            else
            {
                if(interactedObject.GetComponent<OnTrigger>().interacted == false)
                {
                    interactedObject.GetComponent<OnTrigger>().PlayAudio();
                }
                else
                {
                    interactedObject.GetComponent<OnTrigger>().StopAudio();
                }
            }
        }
    }

    public void GetIntractableObject(GameObject obj)
    {
        interactedObject = obj;
    }

    public void RemoveIntractableObject()
    {
        interactedObject = null;
    }
}
