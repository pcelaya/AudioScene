using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float circleRadius = 5f;

    private Vector3 centerPosition;
    private float angle;

    private void Start()
    {
        centerPosition = transform.position;
        if (animator != null)
        {
            animator.SetFloat("Speed", 0.5f);
        }
    }

    private void Update()
    {
        MoveInCircle();
        UpdateRotation();
    }

    private void MoveInCircle()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * circleRadius;
        float z = Mathf.Sin(angle) * circleRadius;

        transform.position = centerPosition + new Vector3(x, 0, z);
    }

    private void UpdateRotation()
    {
        // Calcular dirección tangente al círculo
        Vector3 tangentDirection = new Vector3(-Mathf.Sin(angle), 0, Mathf.Cos(angle));
        transform.rotation = Quaternion.LookRotation(tangentDirection);
    }

    private void PlaySkeletonFootstep()
    {
        AudioClip footstep = FootstepManager.Instance.PlayFootstep(FootstepType.Stone);
        audioSource.PlayOneShot(footstep);
    }
}
