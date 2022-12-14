using DG.Tweening;
using UnityEngine;

public class EnemyClimb : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyMovement _enemyMovement;

    private const string Climb = "Climb";

    private Tween _tween;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Lamppost>(out Lamppost lamppost))
        {
            BusyLamppost(lamppost);
            Climbing(lamppost.transform);
        }
    }

    public void Climbing(Transform pointLamppost)
    {
        transform.position = new Vector3(pointLamppost.position.x, 0f, pointLamppost.position.z);

        _animator.SetTrigger(Climb);
        _tween = transform.DOMoveY(pointLamppost.position.y, 3f).SetEase(Ease.Linear);
        _enemyMovement.KillAgent();
    }

    private void BusyLamppost(Lamppost lamppost)
    {
        CapsuleCollider post = lamppost.GetComponent<CapsuleCollider>();
        post.enabled = false;
    }
}