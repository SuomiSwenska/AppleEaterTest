using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private Gameplay _gameplay;
    private RandomPointsGenerator _randomPointsGenerator;
    private ObjectsPool _objectsPool;
    private int pointsCount;

    private void Awake()
    {
        _gameplay = FindObjectOfType<Gameplay>();
        _randomPointsGenerator = FindObjectOfType<RandomPointsGenerator>();
        _objectsPool = FindObjectOfType<ObjectsPool>();
    }

    private void OnEnable()
    {
        _gameplay.OnAppleTake += AppleTakeHandler;
        _gameplay.OnStartButtonDown += SetNewApples;
        _gameplay.OnPlayerDeath += ReturnApplesToObjectPool;
    }

    private void OnDisable()
    {
        _gameplay.OnAppleTake -= AppleTakeHandler;
        _gameplay.OnStartButtonDown -= SetNewApples;
        _gameplay.OnPlayerDeath -= ReturnApplesToObjectPool;
    }

    private void SetNewApples()
    {
        for (int i = 0; i < _gameplay.StartApplesCount; i++)
        {
            Vector3 setPosition = _randomPointsGenerator.GetEmptyPoint();
            Apple newApple = _objectsPool.GetApple();
            newApple.transform.position = setPosition;
        }

        pointsCount = 0;
    }

    private void AppleTakeHandler(Apple apple)
    {
        pointsCount++;
        _objectsPool.AddAppleToPool(apple);
        _gameplay.OnUpdateUIPoints?.Invoke(pointsCount);
        Saver.instance.SaveResult(pointsCount);
    }

    private void ReturnApplesToObjectPool()
    {
        _objectsPool.TurnToPoolApples();
        _objectsPool.TurnToPoolEnemies();
    }
}
