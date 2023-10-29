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
        Vector3 point = _randomPoints[0];
        _randomPoints.RemoveAt(0);
        return point;
    }

    private void CreateNewRandomPoint()
    {
        for (int i = 0; i < _pointsCount; i++)
        {
            float distance = Random.Range(_distanceRange.x, _distanceRange.y);
            float angle = Random.Range(0, 2 * Mathf.PI);

            Vector3 randomPoint = new Vector3(distance * Mathf.Cos(angle), 0, distance * Mathf.Sin(angle)
            );

            Debug.Log("Random Point " + i + ": " + randomPoint);

            Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), randomPoint, Quaternion.identity);
        }
    }
}
