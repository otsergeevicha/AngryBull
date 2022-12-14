using System;
using UnityEngine;


public class EnemyStateDie : EnemyState
{
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private BoxCollider _collider;

    public event Action Died;

    private void Start()
    {
        Died?.Invoke();
        _collider.enabled = false;
        Enemy.ChangeSpeed(GetSpeed());
        _enemyMovement.EnemyDie();
    }

    public override float GetSpeed() {return 0;}
}