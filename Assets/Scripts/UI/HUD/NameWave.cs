using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class NameWave : MonoBehaviour
{
    [SerializeField] private WaveFactory _waveFactory;
    [SerializeField] private TMP_Text _tmp;

    private float _timer = 2f;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _waveFactory.WaveChanged += SetName;
    }

    private void OnDisable()
    {
        _waveFactory.WaveChanged -= SetName;
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void SetName()
    {
        _timer = 2f;
        _tmp.text = _waveFactory.NameWave;
    }

    private void UpdateTimer()
    {
        if(_timer <= 0)
        {
            _tmp.text = "";
            return;
        }
        
        _timer -= Time.deltaTime;
    }
}