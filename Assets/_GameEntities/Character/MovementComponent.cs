using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class MovementComponent
{
    public Action OnDestinationReached;

    protected Transform _characterTransform;
    protected CharacterData _characterData;
    protected bool _onRoute;

    protected Vector3 _target;
    protected float _startTime;
    protected float _duration;

    public abstract void Init(CharacterData characterData, Transform parentTransform);

    public async void StartMove(Vector3 position)
    {
        _target = position;
        _target.y = 0;

        _startTime = Time.time;
        _duration = Vector3.Distance(_characterTransform.position, _target) / _characterData.MovingSpeed;

        try
        {
            if (_onRoute) return;
            await MoveTask();
        }
        catch (OperationCanceledException)
        {
            Debug.Log("MoveTask OperationCanceledException");
        }
    }

    protected async Task MoveTask()
    {
        _onRoute = true;

        while (Vector3.Distance(_characterTransform.position, _target) >= 0.05f)
        {
            float step = _characterData.MovingSpeed * Time.deltaTime;
            _characterTransform.position = Vector3.MoveTowards(_characterTransform.position, _target, step);
            await Task.Delay(5);
            if (_characterTransform == null) return;
        }

        _characterTransform.position = _target;

        DestinationReached();
    }

    protected void DestinationReached()
    {
        OnDestinationReached?.Invoke();
        _onRoute = false;
    }
}
