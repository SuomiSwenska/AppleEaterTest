using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IMovable
{
    private Gameplay _gameplay;
    private bool _inContact;
    private IMovable _movable;
    private RandomPointsGenerator _randomPointsGenerator;

    [SerializeField] private float _contactDelay;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Vector2 routeChangeDelay;

    private Vector3 _currentRourteTarget;

    private void Awake()
    {
        _randomPointsGenerator = FindObjectOfType<RandomPointsGenerator>();
        _gameplay = FindObjectOfType<Gameplay>();
        _movable = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector3.Distance(transform.position, collision.transform.position) <= 1f)
        {
            Debug.Log("Enemy collision on distance: " + Vector3.Distance(transform.position, collision.transform.position), collision.transform);
            HitPlayer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _inContact = false;
    }

    public void Init()
    {
        StopAllCoroutines();
        StartCoroutine(RouteCoroutine());
        StartCoroutine(RouteTargetChanerCoroutine());
    }

    private IEnumerator RouteCoroutine()
    {
        _currentRourteTarget = _randomPointsGenerator.GetRandomPointToRoute();

        while (true)
        {
            float step = _movingSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _currentRourteTarget, step);
            yield return null;
        }
    }

    private IEnumerator RouteTargetChanerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(routeChangeDelay.x, routeChangeDelay.y));
            _currentRourteTarget = _randomPointsGenerator.GetRandomPointToRoute();
        }
    }

    private void HitPlayer()
    {
        StartCoroutine(HitPlayerCoroutine());
    }

    private IEnumerator HitPlayerCoroutine()
    {
        _inContact = true;
        _gameplay.OnEnemyTouch?.Invoke();

        while (_inContact)
        {
            yield return new WaitForSeconds(_contactDelay);
            _gameplay.OnEnemyTouch?.Invoke();
        }
    }

    void IMovable.Move(Vector3 position)
    {
        throw new System.NotImplementedException();
    }
}
