using UnityEngine;

public abstract class EnemyTransition : MonoBehaviour
{
    [SerializeField] protected Enemy Enemy;

    protected const float DistanceFear = 15f;
    protected Player Player;
    protected float CurrentDistance;
    
    private void OnEnable()
    {
        Enemy.WokeUp += SetPlayer;
    }

    private void OnDisable()
    {
        Enemy.WokeUp -= SetPlayer;
    }

    private void SetPlayer(Player player)
    {
        Player = player;
    }
    
    public abstract EnemyState GetState();
}