using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(ShakeRoutine(0.5f, 0.2f, 5));
    }

    private IEnumerator ShakeRoutine(float duration, float strength, int vibrato)
    {
        Vector3 originalScale= transform.localScale;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = (-Mathf.Sin(t * vibrato * Mathf.PI * 2) * strength * Mathf.Lerp(1, 0, t / duration) + 1) * originalScale;
            yield return null;
        }
    }
}
