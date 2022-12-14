using UnityEngine;

public class EnemyTransitionFear : EnemyTransition
{
    [SerializeField] private EnemyState _enemyStateFear;

    public override EnemyState GetState()
    {
        CurrentDistance = Vector3.Distance(Enemy.transform.position, Player.Position);
        
        if(Enemy.Alive && CurrentDistance <= DistanceFear)
            return _enemyStateFear;
        
        return null;
    }
}