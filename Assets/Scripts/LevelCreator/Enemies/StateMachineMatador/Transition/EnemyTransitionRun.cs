using UnityEngine;

public class EnemyTransitionRun : EnemyTransition
{
    [SerializeField] private EnemyState _enemyStateRun;

    public override EnemyState GetState()
    {
        CurrentDistance = Vector3.Distance(Enemy.transform.position, Player.Position);

        if(Enemy.Alive && CurrentDistance > DistanceFear)
        {
            return _enemyStateRun;
        }


        return null;
    }
}