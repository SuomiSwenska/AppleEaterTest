using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private Gameplay _gameplay;

    private void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
    }

    private void OnEnable()
    {
        _gameplay.OnAppleTake += AppleTakeHandler;
    }

    private void OnDisable()
    {
        _gameplay.OnAppleTake -= AppleTakeHandler;
    }

    private void AppleTakeHandler(Apple apple)
    {
        apple.gameObject.SetActive(false);
    }
}
