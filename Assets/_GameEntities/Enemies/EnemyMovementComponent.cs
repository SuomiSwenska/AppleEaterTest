using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementComponent : MovementComponent
{
    public override void Init(CharacterData characterData, Transform transform)
    {
        _characterData = characterData as EnemyData;
        _characterTransform = transform;
    }
}
