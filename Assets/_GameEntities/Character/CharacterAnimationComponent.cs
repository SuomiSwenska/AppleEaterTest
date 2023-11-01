using System;
using System.Threading;
using System.Linq;
using UnityEngine;

public class CharacterAnimationComponent
{
    private AstronautAnimation[] _astronautAnimations;

    private EnumAnimationState _characterAnimationState;
    private EnumAnimationSide _characterAnimationSide;

    private Transform _characterTransform;
    private GameObject _currentAnimationGO;

    public void Init(CharacterData characterData, Transform parentTransform)
    {
        _characterTransform = parentTransform;
        _astronautAnimations = parentTransform.GetComponentsInChildren<AstronautAnimation>();

        _characterAnimationState = characterData.CharacterAnimationStateDef;
        _characterAnimationSide = characterData.CharacterAnimationSideDef;

        AnimationsGODisable();
        AnimationSwitcher();
    }

    public void ChangeAnimationState(Vector3 targetPosition)
    {
        _characterAnimationState = EnumAnimationState.Walk;
        _characterAnimationSide = GetMovingSide(targetPosition);

        AnimationSwitcher();
    }

    public void SetIdleAnimation()
    {
        _characterAnimationState = EnumAnimationState.Idle;
        AnimationSwitcher();
    }

    private EnumAnimationSide GetMovingSide(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - _characterTransform.position;
        direction.y = 0;

        float angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);

        switch (angle)
        {
            case float a when (a > 45f && a <= 135f):
                return EnumAnimationSide.Right;
            case float a when (a > -135f && a <= -45f):
                return EnumAnimationSide.Left;
            case float a when (a > 135f || a <= -135f):
                return EnumAnimationSide.Down;
            default:
                return EnumAnimationSide.Up;
        }
    }

    private void AnimationSwitcher()
    {
        var matchingAnimation = _astronautAnimations.FirstOrDefault(animation =>
        animation.AnimationSide == _characterAnimationSide && animation.AnimationState == _characterAnimationState);

        if (matchingAnimation == null) Debug.LogError("Correct animation is empty: " + _characterAnimationSide + " with state " + _characterAnimationState);
        else
        {
            if (_currentAnimationGO != null) _currentAnimationGO.SetActive(false);
            _currentAnimationGO = matchingAnimation.gameObject;
            _currentAnimationGO.SetActive(true);
            Debug.Log("Animation changed to: " + _characterAnimationSide + " with state " + _characterAnimationState);
        }
    }

    private void AnimationsGODisable()
    {
        foreach (var item in _astronautAnimations)
        {
            item.gameObject.SetActive(false);
        }
    }
}
