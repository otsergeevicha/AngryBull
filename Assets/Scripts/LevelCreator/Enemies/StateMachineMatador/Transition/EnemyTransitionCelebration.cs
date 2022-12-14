using UnityEngine;

public class EnemyTransitionCelebration : EnemyTransition
{
    [SerializeField] private EnemyStateCelebration _enemyStateCelebration;

    private EnemySafePoint _enemySafePoint;

    public override EnemyState GetState()
    {
        return transform.position == _enemySafePoint.Position ? _enemyStateCelebration : null;
    }
}
