using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttackComponent
{
    public Action<float> OnHitPlayer;

    private EnemyData _enemyData;
    private Transform _characterTransform;
    private float _detectDelay;

    private Collider2D _currentCollider;

    public void Init(CharacterData characterData, Transform transform)
    {
        _enemyData = characterData as EnemyData;
        _characterTransform = transform;
        _detectDelay = _enemyData.DefaultDetectDelay;
    }

    public void StartDetectCollision()
    {
        DetectHitCollision();
    }

    private void GetOverlapCircle()
    {
        _currentCollider = Physics2D.OverlapCircle(_characterTransform.position, _enemyData.DetectRadius);

        if (_currentCollider != null && Vector3.Distance(_characterTransform.position, _currentCollider.transform.position) <= _enemyData.DetectRadius && _currentCollider.CompareTag("Player"))
        {
            _detectDelay = _enemyData.ContactDelay;
            OnHitPlayer?.Invoke(_enemyData.HitDamage);
        }
        else _detectDelay = _enemyData.DefaultDetectDelay;
    }

    private async void DetectHitCollision()
    {
        while (true)
        {
            await HitPlayerCoroutine();
            if (_characterTransform == null) return;
            GetOverlapCircle();
        }
    }

    private async Task HitPlayerCoroutine()
    {
        await Task.Delay(TimeSpan.FromSeconds(_detectDelay));
    }
}
