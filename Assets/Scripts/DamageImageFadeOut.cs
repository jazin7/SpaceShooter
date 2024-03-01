using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageImageFadeOut : MonoBehaviour
{
    private float fadeDuration = 1f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        for (float t = 0f; t < fadeDuration; t += Time.deltaTime)
        {
            // Change the alpha over time
            float normalizedTime = t / fadeDuration;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f - normalizedTime);

            yield return null;
        }

        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        Destroy(gameObject);
    }
}