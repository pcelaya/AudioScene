• Static 3D emitter sounds: Campfire, Water Leak, Wood Crack, Piano, Bottles

• Keyframe-based event sounds: Skeleton Footsteps

• Using triggers: piano, campfire and bottles

• Using mixers: 3 mixers (SFX, Music & Ambiance)

• Audio mixer snapshot changes: indoor, outdoor

• Audio Clip Load Type: Music (Streaming), Fur Elise (compressed in memory), SFX (Decompressed Load)

You start at the harbor where you can hear the music, the wind and the waves. As you move forward with the player you will hear the footsteps, wooden or rock footsteps depending on where you step, these also sound faster when you sprint and slower when you crouch. You can interact with the fisherman. The noise of the campfire will start to be heard as you get closer, and will get louder and louder as you get closer. You can interact with it by pressing E and it will make a sound effect. The patrolling skeleton makes noise when it steps on the ground and this comes from its feet, the closer you get the louder it gets. You can interact with the piano with the E and fur Elise will start to sound, you can stop it by interacting again, this is also 3d, when you move away you will hear less. If you enter in an interior zone the music, the wind and the waves are less audible and also a low pass of them is made. In the upstairs room you can hear drops of water falling, the crack of the wood and you can interact with the bottles which will make a sound effect. Also when you go indoors you can hear echoes and reverberation.

public void SetGameObjectActive(bool active)
{
    ObjectToToggle.SetActive(active);

    if (ResetSelectionAfterClick)
        EventSystem.current.SetSelectedGameObject(null);

    if (active) maximizeSFX.Play();
    else minimizeSFX.Play();
}


public class LoadSceneButton : MonoBehaviour
{
   public string SceneName = "";

  [SerializeField] private AudioSource selectSFX;
	  
   //More code que no tienes que tocar	

    public void LoadTargetScene()
    {
        selectSFX.Play();
        SceneManager.LoadScene(SceneName);
    }
}


if (m_FootstepDistanceCounter >= 1f / chosenFootstepSfxFrequency)
{
    m_FootstepDistanceCounter = 0f;

    AudioSource.pitch = Random.Range(0.8f, 1.2f);
    AudioSource.PlayOneShot(FootstepSfx, Random.Range(0.5f, 1.0f));
}


public class HurtSound : MonoBehaviour
{
    [SerializeField] private AudioSource hurtSFX;

    public void PlayHurtSound()
    {
        if (hurtSFX != null)
        {
            hurtSFX.Play();
        }
    }
}

using UnityEngine.Audio;

[RequireComponent(typeof(Collider))]
public class SnapshotChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot m_insideSnapshot;
    [SerializeField] private AudioMixerSnapshot m_outsideSnapshot;

    [SerializeField] private float m_transitionTime = 0.5f;

    private enum SnapshotState { Inside, Outside }
    private SnapshotState m_currentState = SnapshotState.Inside;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inside") && m_currentState != SnapshotState.Inside)
        {
            m_insideSnapshot.TransitionTo(m_transitionTime);
            m_currentState = SnapshotState.Inside;
        }
        else if (other.CompareTag("Outside") && m_currentState != SnapshotState.Outside)
        {
            m_outsideSnapshot.TransitionTo(m_transitionTime);
            m_currentState = SnapshotState.Outside;
        }
    }
}

