using System;
using Random = System.Random;
using UnityEngine;

public class EnemyStateFear : EnemyState
{
    private const int MinSpeed = 5;
    private const int MaxSpeed = 6;

    private const int MaxChance = 2;
    private const int MinChance = 0;

    public event Action<Transform> Feared;

    private Transform _newTarget;
    private Random _random = new Random();
    
    private void Start()
    {
        Enemy.ChangeSpeed(GetSpeed());
    }

    private void OnEnable()
    {
        CheckChance();
    }

    public override float GetSpeed()
    {
        return _random.Next(MinSpeed, MaxSpeed);
    }

    private void CheckChance()
    {
        int probabilityPositionChange = _random.Next(MinChance, MaxChance);

        if(probabilityPositionChange == MaxChance)
            Feared?.Invoke(ChangeTarget());
    }

    private Transform ChangeTarget()
    {
        SearchNearestTarget();

        return _newTarget;
    }

    private void SearchNearestTarget()
    {
        float minDistance = Vector3.Distance(transform.position, Enemy.Target.position);

        foreach(var safePoint in Enemy.SafePoints)
        {
            float currentDistance = Vector3.Distance(transform.position, safePoint.position);
            
            if(minDistance > currentDistance)
            {
                minDistance = currentDistance;
                _newTarget = safePoint;
            }
        }
    }
}