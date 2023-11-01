using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Configs")]
public class CharacterData : ScriptableObject
{
    [SerializeField] protected float movingSpeed;
    [SerializeField] protected GameObject characterPrefab;
    [SerializeField] private float maxHitPoints;

    [SerializeField] private EnumAnimationState _characterAnimationStateDef;
    [SerializeField] private EnumAnimationSide _characterAnimationSideDef;

    public float MovingSpeed { get => movingSpeed; }
    public float MaxHitPoints { get => maxHitPoints; }
    public EnumAnimationState CharacterAnimationStateDef { get => _characterAnimationStateDef; }
    public EnumAnimationSide CharacterAnimationSideDef { get => _characterAnimationSideDef; }
    public GameObject CharacterPrefab { get => characterPrefab; }
}
