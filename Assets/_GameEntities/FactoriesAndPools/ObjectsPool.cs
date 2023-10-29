using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    private List<Apple> _apples;
    private List<GameObject> _enemies;

    private void Awake()
    {
        _apples = new List<Apple>();
        _enemies = new List<GameObject>();
    }

    public Apple GetApple()
    {
        Apple apple = _apples[0];
        _apples.RemoveAt(0);
        apple.gameObject.SetActive(true);
        return apple;
    }

    public void AddAppleToPool(Apple apple)
    {
        _apples.Add(apple);
        apple.gameObject.SetActive(false);
    }

    public GameObject GetEnemyGO()
    {
        GameObject enemyGO = _enemies[0];
        _enemies.RemoveAt(0);
        enemyGO.SetActive(true);
        return enemyGO;
    }

    public void AddEnemyToPool(GameObject enemyGO)
    {
        _enemies.Add(enemyGO);
        enemyGO.SetActive(false);
    }
}
