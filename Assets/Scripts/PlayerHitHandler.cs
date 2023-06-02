using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHitHandler : MonoBehaviour
{
    public float delayBeforeReturnToMenu = 1f;  // Delay in seconds before returning to the menu
    private AudioSource bgmAudioSource;  // Background Music
    public AudioSource explosionAudioSource;  // Explosion sound
    private bool isHit = false;
    private float hitTime;
    public float fadeDuration = 1.0f;  // Duration of the fade-out in seconds

    private void Start()
    {
        bgmAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isHit && collision.CompareTag("EnemyLaser"))
        {
            isHit = true;
            GetComponent<Renderer>().enabled = false; // Make character invisible
            explosionAudioSource.PlayOneShot(explosionAudioSource.clip);
            hitTime = Time.time;
            Destroy(collision.gameObject);
            // Start the fade-out for background music
            StartCoroutine(FadeOut(bgmAudioSource, fadeDuration));
        }
    }

    // Coroutine to fade out an audio source over a certain duration
    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;

            yield return null;
        }

        audioSource.Stop();
    }

    private void Update()
    {
        if (isHit && Time.time >= hitTime + delayBeforeReturnToMenu)
        {
            SceneManager.LoadScene("MainMenu");  // Replace "MainMenu" with the name of your main menu scene
        }
    }
}
