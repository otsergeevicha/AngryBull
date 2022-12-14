using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyRagdollControl))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyRagdollControl _enemyRagControl;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private NavMeshAgent _agent;
    
    private const float TimeFly = 1f;

    private const string Run = "Run";
    private const string Celebration = "Celebration";

    private bool _isSaved = false;

    public void Move(Transform target, float speed)
    {
        if(_isSaved)
            return;

        _animator.SetBool(Run, true);
        _agent.speed = speed;
        _agent.SetDestination(target.position);

        float distance = Vector3.Distance(transform.position, target.position);

        if(distance < 1f)
            CelebrationState();
    }

    public void KillAgent()
    {
        _isSaved = true;
        _agent.enabled = false;
    }

    public void EnemyDie()
    {
        _enemyRagControl.MakePhysical();
        transform.DOMove(_enemy.CameraPoint.position, TimeFly).OnComplete(Off);
    }

    private void CelebrationState()
    {
        _animator.SetBool(Run, false);
        _animator.SetTrigger(Celebration);
        Player player = _enemy.GetPlayer();
        RotateToTarget(player.transform);
        _isSaved = true;
    }

    private void RotateToTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
    
    private void Off()
    {
        gameObject.SetActive(false);
    }
}