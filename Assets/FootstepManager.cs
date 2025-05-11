using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FootstepType
{
    Wood,
    Stone
}

[RequireComponent(typeof(AudioSource))]
public class FootstepManager : MonoBehaviour
{
    public static FootstepManager Instance { get; private set; }

    [SerializeField] private List<AudioClip> woodFootsteps = new List<AudioClip>();
    [SerializeField] private List<AudioClip> stoneFootsteps = new List<AudioClip>();

    private Dictionary<FootstepType, List<AudioClip>> footstepLibrary;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
        InitializeFootstepLibrary();
    }

    private void InitializeFootstepLibrary()
    {
        footstepLibrary = new Dictionary<FootstepType, List<AudioClip>>
        {
            { FootstepType.Wood, woodFootsteps },
            { FootstepType.Stone, stoneFootsteps }
        };
    }

    public void PlayFootstep(FootstepType type)
    {
        if (footstepLibrary.TryGetValue(type, out List<AudioClip> clips))
        {
            if (clips.Count == 0)
            {
                return;
            }

            AudioClip randomClip = clips[Random.Range(0, clips.Count)];
            audioSource.PlayOneShot(randomClip);
        }
    }
}
