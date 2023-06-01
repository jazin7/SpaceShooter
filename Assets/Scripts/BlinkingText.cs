using UnityEngine;
using TMPro;
using System.Collections;


public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float speed = 1.0f;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // fade out
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * speed)
            {
                Color newColor = text.color;
                newColor.a = Mathf.Lerp(1.0f, 0.0f, t);
                text.color = newColor;
                yield return null;
            }

            // fade in
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * speed)
            {
                Color newColor = text.color;
                newColor.a = Mathf.Lerp(0.0f, 1.0f, t);
                text.color = newColor;
                yield return null;
            }
        }
    }
}
