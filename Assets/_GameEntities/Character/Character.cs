using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Action OnDestinationReached;

    [SerializeField] private CharacterData _characterData;

    private GameObject _characterBodyGO;
    private CharacterMovementConmpnent _characterMovement;
    private CharacterAnimationComponent _characterAnimation;
    private InputController _inputController;
    private Gameplay _gameplay;
    public CharacterData CharacterData { get => _characterData; }

    private void Awake()
    {
        _inputController = FindObjectOfType<InputController>();
        _gameplay = FindObjectOfType<Gameplay>();

        InstantiateCharacterBody();

        _characterMovement = new CharacterMovementConmpnent();
        _characterMovement.Init(_characterData, transform);

        _characterAnimation = new CharacterAnimationComponent();
        _characterAnimation.Init(_characterData, transform);
    }

    private void OnEnable()
    {
        _inputController.OnGetNewMovingPosition += GetNewMovingPositionHandler;
        _characterMovement.OnDestinationReached += SetDefaultAnimation;
    }

    private void OnDisable()
    {
        _inputController.OnGetNewMovingPosition -= GetNewMovingPositionHandler;
        _characterMovement.OnDestinationReached -= SetDefaultAnimation;
    }

    private void InstantiateCharacterBody()
    {
        _characterBodyGO = Instantiate(_characterData.CharacterPrefab, transform);
    }

    public void SetDefaultAnimation()
    {
        _characterAnimation.SetIdleAnimation();
    }

    private void GetNewMovingPositionHandler(Vector3 targetPosition)
    {
        if (!_gameplay.InPlaing) return;

        _characterMovement.StartMove(targetPosition);
        _characterAnimation.ChangeAnimationState(targetPosition);
    }
}
