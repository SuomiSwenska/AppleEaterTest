using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Configs")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float movingSpeed;
    [SerializeField] private float maxHitPoints;

    public float MovingSpeed { get => movingSpeed; }
    public float MaxHitPoints { get => maxHitPoints; }
}
