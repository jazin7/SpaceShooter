using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHitHandler : MonoBehaviour
{
    public float delayBeforeReturnToMenu = 1f; 
    private AudioSource bgmAudioSource; 
    public AudioSource explosionAudioSource;  
    private bool isHit = false;
    private float hitTime;
    public float fadeDuration = 1.0f;  


    public GameObject explosionParticlePrefab; 


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
            Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);

            StartCoroutine(FadeOut(bgmAudioSource, fadeDuration));
        }
    }

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
            SceneManager.LoadScene("MainMenu"); 
        }
    }
}
