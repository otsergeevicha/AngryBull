using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float _currentSpeed = 8f;
    private float _savedSpeed = 8f;

    private float _timerBurstSpeed = 2f;

    public float CurrentSpeed => _currentSpeed;

    private void OnTriggerEnter(Collider collision)
    {
        if(!collision.TryGetComponent<Villian>(out Villian villian))
            return;
        
        ApplyBurstSpeed(villian.BurstSpeed);
    }

    private void ApplyBurstSpeed(float speed)
    {
        OnSpeed(speed);
        Invoke(nameof(OffSpeed), _timerBurstSpeed);
    }

    private void OnSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    private void OffSpeed()
    {
        _currentSpeed = _savedSpeed;
    }
}