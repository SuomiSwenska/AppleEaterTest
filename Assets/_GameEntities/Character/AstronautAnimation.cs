using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAnimation : MonoBehaviour
{
    [SerializeField] private EnumAnimationSide _animationSide;
    [SerializeField] private EnumAnimationState _animationState;

    public EnumAnimationSide AnimationSide { get => _animationSide; }
    public EnumAnimationState AnimationState { get => _animationState; }
}
