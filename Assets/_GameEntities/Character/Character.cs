using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMovable, IDamageable
{
    public Action OnAnimationChanged;
    public Action OnAppleTake;
    public Action OnDamage;
    public Action OnDeath;

    [SerializeField] private CharacterData _characterData;

    [SerializeField] private EnumAnimationState _characterAnimationState;
    [SerializeField] private EnumAnimationSide _characterAnimationSide;

    private InputController _inputController;
    private IMovable _movable;
    private IDamageable _damageable;

    private bool _onRoute;

    public EnumAnimationState CharacterAnimationState { get => _characterAnimationState; private set => _characterAnimationState = value; }
    public EnumAnimationSide CharacterAnimationSide { get => _characterAnimationSide; private set => _characterAnimationSide = value; }

    private void Awake()
    {
        _inputController = FindObjectOfType<InputController>();
        _movable = this;
        _damageable = this;
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

        _movable.Move(targetPosition);

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

    void IMovable.Move(Vector3 position)
    {
        if (_onRoute)
        {
            StopAllCoroutines();
            _onRoute = false;
        }

        StartCoroutine(MoveCoroutine(position));
    }

    void IDamageable.GetDamage()
    {
        throw new NotImplementedException();
    }

    void IDamageable.Death()
    {
        throw new NotImplementedException();
    }

    private IEnumerator MoveCoroutine(Vector3 position)
    {
        _onRoute = true;
        Vector3 startPosition = transform.position;
        position.y = 0;
        float distance = Vector3.Distance(startPosition, position);

        while (transform.position != position)
        {
            float step = _characterData.MovingSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, position, step);

            yield return null;
        }

        DestinationReached();
    }

    private void DestinationReached()
    {
        _onRoute = false;
        _characterAnimationState = EnumAnimationState.Idle;
        OnAnimationChanged?.Invoke();
    }
}
