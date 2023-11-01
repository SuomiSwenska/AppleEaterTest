using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyConfigs")]
public class EnemyData : CharacterData
{
    [SerializeField] private float contactDelay;
    [SerializeField] private float defaultDetectDelay;
    [SerializeField] private Vector2 routeChangeDelay;
    [SerializeField] private float hitDamage;
    public GameObject EnemyPrefab { get => characterPrefab; }
    public float ContactDelay { get => contactDelay; }
    public Vector2 RouteChangeDelay { get => routeChangeDelay; }
    public float HitDamage { get => hitDamage;  }
    public float DefaultDetectDelay { get => defaultDetectDelay; }
}
