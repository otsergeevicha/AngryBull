using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(EnemyRagdollControl))]
[RequireComponent(typeof(Animator))]
public class Villian : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyRagdollControl _ragdollControl;

    private const string TauntAnimation = "Tease";
    
    private const float TimeFly = 2.5f;

    public float BurstSpeed = 18f;

    private Transform _playerPosition;
    private Transform _cameraPoint;
    private float _center = 0f;
    private float _leftCurb = -22f;
    private Sequence _sequence;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent<Player>(out Player _))
            Die();

        if(!collision.TryGetComponent(out ObserverLevel _))
            return;

        LiveCycle();
    }

    public void Init(Vector3 spawnPoint, Transform playerPosition, Transform cameraPoint)
    {
        _cameraPoint = cameraPoint;
        _playerPosition = playerPosition;
        transform.position = spawnPoint;
    }

    private void LiveCycle()
    {
        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOMoveX(_center, _speed).SetEase(Ease.Linear));

        _sequence.AppendCallback(() =>
        {
            transform.DOLookAt(_playerPosition.position, .1f);
            _animator.SetTrigger(TauntAnimation);
        });

        _sequence.AppendInterval(1.5f);
        _sequence.Append(transform.DOLookAt(new Vector3(_leftCurb, transform.position.y, transform.position.z), .1f));
        _sequence.Append(transform.DOMoveX(_leftCurb, _speed).SetEase(Ease.Linear)).OnComplete(Off);
    }

    private void Die()
    {
        _ragdollControl.MakePhysical();
        transform.DOMove(_cameraPoint.position, TimeFly).OnComplete(Off);
    }

    private void Off()
    {
        gameObject.SetActive(false);
    }
}