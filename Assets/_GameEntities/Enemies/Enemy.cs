using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;

    private Gameplay _gameplay;
    private RandomPointsGenerator _randomPointsGenerator;
    private EnemyMovementComponent _enemyMovement;
    private EnemyAttackComponent _enemyAttack;

    private void Awake()
    {
        _randomPointsGenerator = FindObjectOfType<RandomPointsGenerator>();
        _gameplay = FindObjectOfType<Gameplay>();

        _enemyMovement = new EnemyMovementComponent();
        _enemyMovement.Init(enemyData, transform);

        _enemyAttack = new EnemyAttackComponent();
        _enemyAttack.Init(enemyData, transform);
        _enemyAttack.StartDetectCollision();
    }

    private void OnEnable()
    {
        _enemyMovement.OnDestinationReached += Init;
        _enemyAttack.OnHitPlayer += AttackPlayer;
    }

    private void OnDisable()
    {
        _enemyMovement.OnDestinationReached -= Init;
        _enemyAttack.OnHitPlayer -= AttackPlayer;
    }

    public void Init()
    {
        StopAllCoroutines();
        StartCoroutine(InitCoroutine());
    }

    private IEnumerator InitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _enemyMovement.StartMove(_randomPointsGenerator.GetRandomPointToRoute());
    }

    private void AttackPlayer(float damage)
    {
        _gameplay.OnEnemyTouch?.Invoke();
    }
}
