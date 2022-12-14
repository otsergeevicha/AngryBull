using System;
using UnityEngine;

public class EnemyTransitionDie : EnemyTransition
{
    [SerializeField] private EnemyState _enemyStateDie;

    public event Action TransitionDied;

    private bool _isCollision = false;

    private void OnTriggerEnter(Collider collision)
    {
        if(!collision.TryGetComponent<Player>(out var _))
            return;
        
        _isCollision = true;
        TransitionDied?.Invoke();
    }

    public override EnemyState GetState()
    {
        return _isCollision ? _enemyStateDie : null;
    }
}