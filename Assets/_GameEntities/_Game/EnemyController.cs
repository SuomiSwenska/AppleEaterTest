using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
        _gameplay.OnStartButtonDown += SetNewEnemies;
    }

    private void OnDisable()
    {
        _gameplay.OnStartButtonDown -= SetNewEnemies;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        SetNewEnemies();
    }

    private void SetNewEnemies()
    {
        for (int i = 0; i < _gameplay.StartEnemiesCount; i++)
        {
            Vector3 setPosition = _randomPointsGenerator.GetEmptyPoint();
            GameObject newEnemy = _objectsPool.GetEnemyGO();
            newEnemy.transform.position = setPosition;
            newEnemy.transform.eulerAngles = new Vector3(80,0,0);
            newEnemy.GetComponent<Enemy>().Init();
        }
    }

}
