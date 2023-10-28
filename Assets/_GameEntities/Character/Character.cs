using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Action OnAnimationChanged;

    [SerializeField] private EnumAnimationState _characterAnimationState;
    [SerializeField] private EnumAnimationSide _characterAnimationSide;

    private InputController _inputController;

    public EnumAnimationState CharacterAnimationState { get => _characterAnimationState; private set => _characterAnimationState = value; }
    public EnumAnimationSide CharacterAnimationSide { get => _characterAnimationSide; private set => _characterAnimationSide = value; }

    private void Awake()
    {
        _inputController = FindObjectOfType<InputController>();
    }

    private void Start()
    {
        OnAnimationChanged?.Invoke();
    }

    private void OnEnable()
    {
        _inputController.OnGetNewMovingPosition += GetNewMovingPositionHandler;
    }

    private void OnDisable()
    {
        _inputController.OnGetNewMovingPosition -= GetNewMovingPositionHandler;
    }

    private void GetNewMovingPositionHandler(Vector3 targetPosition)
    {
        _characterAnimationState = EnumAnimationState.Walk;
        _characterAnimationSide = GetMovingSide(targetPosition);

        OnAnimationChanged?.Invoke();
    }

    private EnumAnimationSide GetMovingSide(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;

        float angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);

        switch (angle)
        {
            case float a when(a > 45f && a <= 135f):
                return EnumAnimationSide.Right;
            case float a when(a > -135f && a <= -45f):
                return EnumAnimationSide.Left;
            case float a when(a > 135f || a <= -135f):
                return EnumAnimationSide.Down;
            default:
                return EnumAnimationSide.Up;
        }
    }
}
