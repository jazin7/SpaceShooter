using UnityEngine;
using TMPro;

public class GodMode : MonoBehaviour
{
    private AudioSource godModeAudioSource; // AudioSource for the God Mode sound effect
    public TextMeshProUGUI godModeIndicator; // TextMeshPro object to indicate God Mode is active
    public BoxCollider2D playerHitbox; // The player's hitbox

    private bool godMode = false; // Whether God Mode is currently active

    private void Start()
    {
        // Load the God Mode audio clip and setup the AudioSource
        AudioClip godModeClip = Resources.Load<AudioClip>("Audio/SFXOk");
        godModeAudioSource = gameObject.AddComponent<AudioSource>();
        godModeAudioSource.clip = godModeClip;

        // Initially hide the godModeIndicator
        godModeIndicator.gameObject.SetActive(false);
    }

    private void Update()
    {
        // If the G key is pressed, toggle God Mode
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
