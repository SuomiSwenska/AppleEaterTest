using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public Action<Apple> OnAppleTake;
    public Action OnEnemyTouch;
    public Action OnPlayerDeath;
    public Action OnStartButtonDown;
    public Action<float> OnUpdateUIHealth;
    public Action<int> OnUpdateUIPoints;

    [SerializeField] private int _startApplesCount;
    [SerializeField] private int _startEnemiesCount;
    [SerializeField] private float _touchDamage;

    public int StartApplesCount { get => _startApplesCount; }
    public int StartEnemiesCount { get => _startEnemiesCount; }
    public float TouchDamage { get => _touchDamage; }
}
