using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float duration = 1.0f; // Duração total da animação em segundos

    private float elapsedTime = 0.0f; // Tempo acumulado desde o início

    private void OnEnable()
    {
        StartCoroutine(EnableShield());
    }

    IEnumerator EnableShield()
    {
        float startValue = 1.0f;
        float endValue = 0.0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            material.SetFloat("_AlphaThreshold", Mathf.Lerp(startValue, endValue, t));

            elapsedTime += Time.deltaTime;
            yield return null; // Aguarda o próximo quadro
        }

        // Garante que o valor final seja exatamente o desejado
        material.SetFloat("_AlphaThreshold", endValue);
        elapsedTime = 0.0f;
    }

    IEnumerator DisableShield()
    {
        float startValue = 0.0f;
        float endValue = 1.0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            material.SetFloat("_AlphaThreshold", Mathf.Lerp(startValue, endValue, t));

            elapsedTime += Time.deltaTime;
            yield return null; // Aguarda o próximo quadro
        }

        // Garante que o valor final seja exatamente o desejado
        material.SetFloat("_AlphaThreshold", endValue);
        elapsedTime = 0.0f;
    }
}

