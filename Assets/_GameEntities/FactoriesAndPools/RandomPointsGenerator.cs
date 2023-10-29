using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointsGenerator : MonoBehaviour
{
    [SerializeField] private List<Vector3> _randomPoints;
    [SerializeField] private int _pointsCount;
    [SerializeField] private Vector2 _distanceRange;

    private void Start()
    {
        CreateNewRandomPoint();
    }

    public Vector3 GetEmptyPoint()
    {
        int randomPointIndex = Random.Range(0, _randomPoints.Count);
        Vector3 point = _randomPoints[randomPointIndex];
        _randomPoints.RemoveAt(randomPointIndex);
        return point;
    }

    public Vector3 GetRandomPointToRoute()
    {
        float distance = Random.Range(_distanceRange.x * 2, _distanceRange.y *2);
        float angle = Random.Range(0, 2 * Mathf.PI);

        Vector3 randomPoint = new Vector3(distance * Mathf.Cos(angle), 0, distance * Mathf.Sin(angle));
        return randomPoint;
    }

    private void CreateNewRandomPoint()
    {
        _randomPoints = new List<Vector3>();

        for (int i = 0; i < _pointsCount; i++)
        {
            float distance = Random.Range(_distanceRange.x, _distanceRange.y);
            float angle = Random.Range(0, 2 * Mathf.PI);

            Vector3 randomPoint = new Vector3(distance * Mathf.Cos(angle), 0.05f, distance * Mathf.Sin(angle));
            _randomPoints.Add(randomPoint);
        }
    }
}
