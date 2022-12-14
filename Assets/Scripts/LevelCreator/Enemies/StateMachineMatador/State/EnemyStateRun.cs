using System;

public class EnemyStateRun : EnemyState
{
    private const int MinSpeed = 4;
    private const int MaxSpeed = 5;
    private Random _random = new Random();

    private void Start()
    {
        Enemy.ChangeSpeed(GetSpeed());
    }

    public override float GetSpeed()
    {
        return _random.Next(MinSpeed, MaxSpeed);
    }
}