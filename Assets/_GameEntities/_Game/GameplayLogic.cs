using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLogic : MonoBehaviour
{
    private Gameplay _gameplay;
    private float _health;

    private void Awake()
    {
        _gameplay = GetComponent<Gameplay>();
    }

    private void OnEnable()
    {
        _gameplay.OnEnemyTouch += HitReaction;
        _gameplay.OnStartButtonDown += ChangeGameStateInPlaying;
        _gameplay.OnPlayerDeath += ChangeGameStateInWaiting;
    }

    private void OnDisable()
    {
        _gameplay.OnEnemyTouch -= HitReaction;
        _gameplay.OnStartButtonDown -= ChangeGameStateInPlaying;
        _gameplay.OnPlayerDeath -= ChangeGameStateInWaiting;
    }

    private void HitReaction()
    {
        _health -= _gameplay.TouchDamage;
        _gameplay.OnUpdateUIHealth?.Invoke(_health);
        if (_health <= 0) _gameplay.OnPlayerDeath?.Invoke();
        Debug.Log("Hit player health = " + _health);
    }

    private void ChangeGameStateInPlaying()
    {
        _health = _gameplay.Character.CharacterData.MaxHitPoints;
        _gameplay.OnUpdateUIHealth?.Invoke(_health);
        _gameplay.OnUpdateUIHealth?.Invoke(0);
        _gameplay.InPlaing = true;
    }

    private void ChangeGameStateInWaiting()
    {
        _gameplay.InPlaing = false;
        _gameplay.Character.Deactivate();
    }
}
