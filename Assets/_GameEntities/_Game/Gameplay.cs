using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public Action<Apple> OnAppleTake;
    public Action OnEnemyTouch;
    public Action OnPlayerDeath;
}
