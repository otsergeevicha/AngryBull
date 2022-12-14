using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private WaveFactory _waveFactory;
    
    private float _wallet = 0;

    public event Action EnemyKilled;
    public event Action<float> WalletChanged;

    public Vector3 Position => transform.position;

    private void OnEnable()
    {
        _waveFactory.WaveChanged += SetPosition;
    }

    private void OnDisable()
    {
        _waveFactory.WaveChanged -= SetPosition;
    }

    public void ApplyMoney(int countMoney)
    {
        WalletChanged?.Invoke(_wallet);
        _wallet += countMoney;
    }

    public void IncreaseSpeed()
    {
        EnemyKilled?.Invoke();
    }

    private void SetPosition()
    {
        transform.position = new Vector3(0f, 1.2f, -8f);
    }
}