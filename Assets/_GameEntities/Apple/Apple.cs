using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Gameplay _gameplay;

    private void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _gameplay.OnAppleTake?.Invoke(this);
    }
}
