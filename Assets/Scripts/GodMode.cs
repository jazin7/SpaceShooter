using UnityEngine;
using TMPro;

public class GodMode : MonoBehaviour
{
    private AudioSource godModeAudioSource; 
    public TextMeshProUGUI godModeIndicator; 
    public BoxCollider2D playerHitbox;

    private bool godMode = false; 

    private void Start()
    {
        AudioClip godModeClip = Resources.Load<AudioClip>("Audio/SFXOk");
        godModeAudioSource = gameObject.AddComponent<AudioSource>();
        godModeAudioSource.clip = godModeClip;

        godModeIndicator.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = !godMode;
            ToggleGodMode(godMode);
        }
    }

    private void ToggleGodMode(bool enable)
    {
        if (enable)
        {
            // Play the God Mode sound effect
            if (godModeAudioSource != null)
            {
                godModeAudioSource.Play();
            }

            // Show the God Mode indicator
            if (godModeIndicator != null)
            {
                godModeIndicator.gameObject.SetActive(true);
            }

            // Disable the player's hitbox
            if (playerHitbox != null)
            {
                playerHitbox.enabled = false;
            }
        }
        else
        {
            // Hide the God Mode indicator
            if (godModeIndicator != null)
            {
                godModeIndicator.gameObject.SetActive(false);
            }

            // Enable the player's hitbox
            if (playerHitbox != null)
            {
                playerHitbox.enabled = true;
            }
        }
    }
}
