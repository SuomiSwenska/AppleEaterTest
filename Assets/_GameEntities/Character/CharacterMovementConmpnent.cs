using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
public class CharacterMovementConmpnent : MovementComponent
{
    public override void Init(CharacterData characterData, Transform transform)
    {
        _characterData = characterData;
        _characterTransform = transform;
    }
}
