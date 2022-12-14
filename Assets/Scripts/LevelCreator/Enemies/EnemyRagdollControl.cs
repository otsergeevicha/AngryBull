using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyRagdollControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbodies;


    private void Start()
    {
        SetRigidbody(_allRigidbodies, true);
    }

    public void MakePhysical()
    {
        _animator.enabled = false;

        SetRigidbody(_allRigidbodies, false);

    }

    private void SetRigidbody(Rigidbody[] array, bool status)
    {
        foreach(Rigidbody rigidbody in _allRigidbodies)
            rigidbody.isKinematic = status;
    }
}