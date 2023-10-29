using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLogic : MonoBehaviour
{
    private Gameplay _gameplay;
    private float health;

    private void Awake()
    {
        _gameplay = GetComponent<Gameplay>();
    }

    private void OnEnable()
    {
        _gameplay.OnEnemyTouch += HitReaction;
    }

    private void OnDisable()
    {
        _gameplay.OnEnemyTouch -= HitReaction;
    }

    private void HitReaction()
    {
        health -= _gameplay.TouchDamage;
        _gameplay.OnUpdateUIHealth?.Invoke(health);
        Debug.Log("Hit player health = " + health);
    }
}
