using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    private List<Apple> _apples;
    private List<Apple> _usedApples;
    private List<GameObject> _enemies;
    private List<GameObject> _usedEnemies;

    private void Awake()
    {
        _apples = new List<Apple>();
        _enemies = new List<GameObject>();
        _usedApples = new List<Apple>();
        _usedEnemies = new List<GameObject>();
    }

    public Apple GetApple()
    {
        Apple apple = _apples[0];
        _apples.RemoveAt(0);
        _usedApples.Add(apple);
        apple.gameObject.SetActive(true);
        return apple;
    }

    public void AddAppleToPool(Apple apple)
    {
        _apples.Add(apple);
        if (_usedApples.Contains(apple)) _usedApples.Remove(apple);
        apple.gameObject.SetActive(false);
    }

    public GameObject GetEnemyGO()
    {
        GameObject enemyGO = _enemies[0];
        _enemies.RemoveAt(0);
        enemyGO.SetActive(true);
        _usedEnemies.Add(enemyGO);
        return enemyGO;
    }

    public void AddEnemyToPool(GameObject enemyGO)
    {
        _enemies.Add(enemyGO);
        if (_usedEnemies.Contains(enemyGO)) _usedEnemies.Remove(enemyGO);
        enemyGO.SetActive(false);
    }

    public void TurnToPoolApples()
    {
        _apples.AddRange(_usedApples);
        _usedApples.Clear();
    }

    public void TurnToPoolEnemies()
    {
        _enemies.AddRange(_usedEnemies);
        _usedEnemies.Clear();
    }
}
