using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDieSound(AudioClip dieSoundClip)
    {
        if (dieSoundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(dieSoundClip);
        }
    }
}
