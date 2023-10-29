using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAnimation : MonoBehaviour
{
    [SerializeField] private float animationSpeed;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.0f;

    private SpriteRenderer _spriteRenderer;
    private Material _defMaterial;
    private Vector3 targetScale;
    private bool isGrowing = true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defMaterial = Instantiate(_spriteRenderer.sharedMaterial);
    }

    private void OnEnable()
    {
        _spriteRenderer.sharedMaterial = _defMaterial;
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        targetScale = new Vector3(minScale, minScale, minScale);

        while (true)
        {
            float t = 0;
            Vector3 startScale = transform.localScale;
            Color startColor = _defMaterial.color;
            Color targetColor;

            if (isGrowing)
            {
                targetColor = new Color(startColor.r, 1.0f, 1.0f, startColor.a);
            }
            else
            {
                targetColor = new Color(startColor.r, 0.0f, 0.0f, startColor.a);
            }

            while (t < 1)
            {
                t += Time.deltaTime * animationSpeed;
                transform.localScale = Vector3.Lerp(startScale, targetScale, t);
                _defMaterial.color = Color.Lerp(startColor, targetColor, t);
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
