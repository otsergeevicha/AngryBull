using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerLevelView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private WindowWin _windowWin;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private VillianSpawner _villianSpawner;

    [SerializeField] private SaveLoad _saveLoad;

    public event Action TimeExpired;

    private float _maxTimeLevel = 25f;
    private float _leftTime = 25f;
    private float _elapsedTime = 0;
    private float _currentTime = 0;
    private float _seconds;

    private void Start()
    {
        _slider.value = 0;
    }

    private void Update()
    {
        if(_currentTime >= 1)
            return;
        
        RenderTimer();
    }

    public void OffWindowWin()
    {
        _maxTimeLevel = 15f;
        _leftTime = 15f;
        _elapsedTime = 0;
        _currentTime = 0;
        _seconds = 0;
        Time.timeScale = 1;
        _windowWin.gameObject.SetActive(false);
    }

    private void RenderTimer()
    {
        _elapsedTime += Time.deltaTime;
        _currentTime = _elapsedTime / _maxTimeLevel;
        _currentTime = Mathf.Clamp(_elapsedTime / _maxTimeLevel, 0, _maxTimeLevel);
        _slider.value = _currentTime;

        UpdateTimer();

        if(_currentTime >= 1)
        {
            Time.timeScale = 0;
            _saveLoad.Save();
            _windowWin.gameObject.SetActive(true);
            TimeExpired?.Invoke();
            _enemySpawner.OffVisible();
            _villianSpawner.OffVisible();
        }
    }

    private void UpdateTimer()
    {
        _leftTime -= Time.deltaTime;

        _seconds = Mathf.FloorToInt(_leftTime);


        if(_leftTime <= 0) return;

        _timer.text = $"0:{_seconds}";
    }
}