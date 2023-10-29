using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _enemyPrefab;

    private Gameplay _gameplay;
    private ObjectsPool _objectsPool;

    private void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
        _objectsPool = GetComponent<ObjectsPool>();
    }

    private void Start()
    {
        CreateApplesToPool();
        CreateEnemiesToPool();
    }

    private void CreateApplesToPool()
    {
        for (int i = 0; i < _gameplay.StartApplesCount; i++)
        {
            GameObject appleGO = Instantiate(_applePrefab);
            _objectsPool.AddAppleToPool(appleGO.GetComponent<Apple>());
        }
    }

    private void CreateEnemiesToPool()
    {
        for (int i = 0; i < _gameplay.StartEnemiesCount; i++)
        {
            GameObject enemyGO = Instantiate(_enemyPrefab);
            _objectsPool.AddEnemyToPool(enemyGO);
        }
    }
}
