using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyRagdollControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbodies;
    [SerializeField] private CapsuleCollider[] _capsuleColliders;
    [SerializeField] private BoxCollider[] _boxColliders;


    private void Start()
    {
        SetRigidbody(_allRigidbodies, true);

        SetColliders(false);
    }

    public void MakePhysical()
    {
        _animator.enabled = false;

        SetColliders(true);
        SetRigidbody(_allRigidbodies, false);
    }

    private void SetColliders(bool status)
    {
        foreach(CapsuleCollider capsuleCollider in _capsuleColliders)
            capsuleCollider.enabled = status;

        foreach(BoxCollider boxCollider in _boxColliders)
            boxCollider.enabled = status;
    }

    private void SetRigidbody(Rigidbody[] array, bool status)
    {
        foreach(Rigidbody rigidbody in _allRigidbodies)
            rigidbody.isKinematic = status;
    }
}