using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLogic : MonoBehaviour
{
    private Gameplay _gameplay;

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
        Debug.Log("Hit player");
    }
}
