using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAnimation : MonoBehaviour
{
    [SerializeField] private float animationSpeed;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.0f;

    private Vector3 targetScale;
    private bool isGrowing = true;

    private void Start()
    {
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        targetScale = new Vector3(minScale, minScale, minScale);

        while (true) // Бесконечный цикл
        {
            float t = 0;
            Vector3 startScale = transform.localScale;

            while (t < 1)
            {
                t += Time.deltaTime * animationSpeed;

                if (isGrowing)
                {
                    transform.localScale = Vector3.Lerp(startScale, targetScale, t);
                }
                else
                {
                    transform.localScale = Vector3.Lerp(startScale, targetScale, t);
                }

                yield return null;
            }

            isGrowing = !isGrowing;

            if (isGrowing)
            {
                targetScale = new Vector3(minScale, minScale, minScale);
            }
            else
            {
                targetScale = new Vector3(maxScale, maxScale, maxScale);
            }

            yield return null;
        }
    }
}
