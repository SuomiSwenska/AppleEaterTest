using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    #region Actions
    public Action<Apple> OnAppleTake;
    public Action OnEnemyTouch;
    public Action OnPlayerDeath;
    public Action OnStartButtonDown;
    public Action<float> OnUpdateUIHealth;
    public Action<int> OnUpdateUIPoints;
    #endregion

    #region Fields
    [Space(10)]
    [SerializeField] private Character _character;
    [Space(10)]
    [SerializeField] private int _startApplesCount;
    [SerializeField] private int _startEnemiesCount;
    [SerializeField] private float _touchDamage;
    [Space(10)]
    [SerializeField] private bool _inPlaing;
    #endregion

    public int StartApplesCount { get => _startApplesCount; }
    public int StartEnemiesCount { get => _startEnemiesCount; }
    public float TouchDamage { get => _touchDamage; }
    public bool InPlaing { get => _inPlaing; set => _inPlaing = value; }
    public Character Character { get => _character; }
}
