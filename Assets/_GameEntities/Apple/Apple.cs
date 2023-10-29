using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Gameplay _gameplay;
    private bool _isActive;

    public bool IsActive { get => _isActive; }

    private void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector3.Distance(transform.position, collision.transform.position) <= 1f)
        {
            Debug.Log("Aplple collision on distance: " + Vector3.Distance(transform.position, collision.transform.position), collision.transform);
            _gameplay.OnAppleTake?.Invoke(this);
        }
    }
}
