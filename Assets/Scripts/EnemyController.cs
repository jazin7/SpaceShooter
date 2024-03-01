using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int startingHealth = 1;

    public GameObject laserPrefab;
    public float shootingInterval = 3f;
    public float speed = 2f;
    public AudioClip hitSoundClip;
    private AudioSource laserShotAudioSourceEnemy; 

    private int currentHealth;
    private float timeSinceLastShot;
    private float startY;
    private bool movingUp = true;
    private float enemyHeight;

    public GameObject explosionParticlePrefab; 
    public GameObject damageImagePrefab;
    private void Start()
    {
        laserShotAudioSourceEnemy = gameObject.AddComponent<AudioSource>();
        laserShotAudioSourceEnemy.clip = Resources.Load<AudioClip>("Audio/SFXLaser7");

        currentHealth = startingHealth;
        startY = transform.position.y;
        enemyHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {

        if (Time.time > timeSinceLastShot + shootingInterval)
        {
            Shoot();

            if (laserShotAudioSourceEnemy != null)
            {
                laserShotAudioSourceEnemy.Play();
            }
            timeSinceLastShot = Time.time;
        }

        float newY = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;
        float clampedY = Mathf.Clamp(newY, -Camera.main.orthographicSize + enemyHeight / 2, Camera.main.orthographicSize - enemyHeight / 2);
        transform.position = new Vector2(transform.position.x, clampedY);

        // Check if enemy reached top or bottom of the screen
        if (movingUp && newY >= Camera.main.orthographicSize - enemyHeight / 2)
        {
            movingUp = false;
        }
        else if (!movingUp && newY <= -Camera.main.orthographicSize + enemyHeight / 2)
        {
            movingUp = true;
        }
    }

    private void Shoot()
    {
        Instantiate(laserPrefab, transform.position + new Vector3(-0.5f, 0f, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        GameObject damageImage = Instantiate(damageImagePrefab, transform.position, Quaternion.identity);


        if (currentHealth <= 0)
        {
            PlayDieSound();
            Die();
            Instantiate(explosionParticlePrefab, transform.position, Quaternion.identity);

        }
        else
        {
            PlayHitSound();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

    }

    private void PlayHitSound()
    {
        if (hitSoundClip != null && laserShotAudioSourceEnemy != null)
        {
            laserShotAudioSourceEnemy.PlayOneShot(hitSoundClip);
        }
    }

    private void PlayDieSound()
    {
        GameObject audioObject = new GameObject("EnemyAudioObject");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Audio/SFXExplo1");
        audioSource.Play();

        // Destroy the audio object after the sound has finished playing
        Destroy(audioObject, audioSource.clip.length);
    }
}
