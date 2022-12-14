using UnityEngine;

public class EnemyStateCelebration : EnemyState
{
    private BoxCollider _collider;
    
    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
    }

    public override float GetSpeed()
    {
        throw new System.NotImplementedException();
    }
}
