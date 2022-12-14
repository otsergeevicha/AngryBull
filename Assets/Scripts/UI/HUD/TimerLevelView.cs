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
    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _hudCanvas;
    [SerializeField] private GameObject _player;

    [SerializeField] private SaveLoad _saveLoad;

    public event Action TimeExpired;

    private float _maxTimeLevel = 20f;
    private float _leftTime = 20f;
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
        _maxTimeLevel = 20f;
        _leftTime = 20f;
        _elapsedTime = 0;
        _currentTime = 0;
        _seconds = 0;
        Time.timeScale = 1;
        _menuCanvas.gameObject.SetActive(false);
        _player.gameObject.SetActive(true);
        _hudCanvas.gameObject.SetActive(true);
        _joystick.SetZeroPosition();
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
            _player.gameObject.SetActive(false);
            _hudCanvas.gameObject.SetActive(false);
            _menuCanvas.gameObject.SetActive(true);
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