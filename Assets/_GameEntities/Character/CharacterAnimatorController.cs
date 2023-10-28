using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    [SerializeField] private AstronautAnimation[] _astronautAnimations;

    private Character _character;
    private GameObject _currentAnimationGO;

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void OnEnable()
    {
        _character.OnAnimationChanged += AnimationSwitcher;
    }

    private void OnDisable()
    {
        _character.OnAnimationChanged -= AnimationSwitcher;
    }

    private void AnimationSwitcher()
    {
        var matchingAnimation = _astronautAnimations.FirstOrDefault(animation =>
        animation.AnimationSide == _character.CharacterAnimationSide && animation.AnimationState == _character.CharacterAnimationState);

        if (matchingAnimation == null) Debug.LogError("Correct animation is empty: " + _character.CharacterAnimationSide + " with state " + _character.CharacterAnimationState);
        else
        {
            if (_currentAnimationGO != null) _currentAnimationGO.SetActive(false);
            _currentAnimationGO = matchingAnimation.gameObject;
            _currentAnimationGO.SetActive(true);
            Debug.Log("Animation changed to: " + _character.CharacterAnimationSide + " with state " + _character.CharacterAnimationState);
        }
    }
}
