using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 7.0f;

    public void StartFade()
    {
        StartCoroutine(FadeOut());
        fadeImage.gameObject.SetActive(true);
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(0, 0, 0, 1); //альфа = 1 , то есть делаем Image непрозрачным

        while(timer < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure the image is completely black at the end.
        fadeImage.color = endColor;
    }
}
