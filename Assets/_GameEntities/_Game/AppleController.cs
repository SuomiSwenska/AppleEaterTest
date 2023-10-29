using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private Gameplay _gameplay;
    private RandomPointsGenerator _randomPointsGenerator;
    private ObjectsPool _objectsPool;

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
    }

    private void OnDisable()
    {
        _gameplay.OnAppleTake -= AppleTakeHandler;
        _gameplay.OnStartButtonDown -= SetNewApples;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        SetNewApples();
    }

    private void SetNewApples()
    {
        for (int i = 0; i < _gameplay.StartApplesCount; i++)
        {
            Vector3 setPosition = _randomPointsGenerator.GetEmptyPoint();
            Apple newApple = _objectsPool.GetApple();
            newApple.transform.position = setPosition;
        }
    }

    private void AppleTakeHandler(Apple apple)
    {
        _objectsPool.AddAppleToPool(apple);
    }
}
