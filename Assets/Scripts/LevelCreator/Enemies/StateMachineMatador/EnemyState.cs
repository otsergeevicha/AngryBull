using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]
public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] protected Enemy Enemy;
    
    protected Rigidbody Rigidbody = new Rigidbody();
    protected Animator Animator = new Animator();

    protected Player Player;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    
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
    
    public void EnterBehavior(EnemyState enterEnemyState)
    {
        if(enterEnemyState != null)
        {
            enterEnemyState.enabled = true;
        }
    }

    public void ExitBehaviour(EnemyState exitEnemyState)
    {
        if(exitEnemyState != null)
        {
            exitEnemyState.enabled = false;
        }
    }

    public abstract float GetSpeed();
}