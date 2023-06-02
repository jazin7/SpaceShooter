using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageImageFadeOut : MonoBehaviour
{
    private float fadeDuration = 1f; // Duration of the fade
    private SpriteRenderer spriteRenderer; // The SpriteRenderer component of the image

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        for (float t = 0f; t < fadeDuration; t += Time.deltaTime)
        {
            // Change the alpha (transparency) over time
            float normalizedTime = t / fadeDuration;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f - normalizedTime);

            yield return null;
        }

        // Ensure the alpha is set to 0 (completely transparent) at the end of the fade
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        // Destroy the game object
        Destroy(gameObject);
    }
}