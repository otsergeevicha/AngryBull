using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private HashAnimation _hashAnimation;
    [SerializeField] private PlayerState _playerState;

    public event Action<float> SpeedChanged;

    private float _speed;

    private void Update()
    {
        SetSpeed();
        Move();
    }

    private void SetSpeed()
    {
        _speed = _playerState.CurrentSpeed;
    }

    private void Move()
    {
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            _animator.SetBool(_hashAnimation.RunBull, true);

        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigidbody.velocity.y, _joystick.Vertical * _speed);

        Rotate();
        SpeedChanged?.Invoke(_speed);
    }

    private void Rotate()
    {
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);

        else
            _animator.SetBool(_hashAnimation.RunBull, false);
    }
}