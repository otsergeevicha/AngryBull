using UnityEngine;

public class LevelDataStars : MonoBehaviour
{
    [SerializeField] private BarView _barView;
    [SerializeField] private TimerLevelView _timerLevel;
    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private SceneController _sceneController;

    private float _result;
    private float _savedResult = 0;
    private int _currentAmountStars;

    private void OnEnable()
    {
        _timerLevel.TimeExpired += OnChangeView;
    }

    private void OnDisable()
    {
        _timerLevel.TimeExpired -= OnChangeView;
    }

    private void OnChangeView()
    {
        _result = _barView.GetProgress();
        NormalizationCountStars();
        _saveLoad.SaveStarsData(_sceneController.CurrentScene, _currentAmountStars);
    }

    private void NormalizationCountStars()
    {
        _savedResult = _result;
        _currentAmountStars = _savedResult switch
        {
            > 0f and < .2f => 0,
            > .2f and < .4f => 1,
            > .4f and < .6f => 2,
            > .6f and < .8f => 3,
            > .8f and < 1f  => 4,
            > 1f            => 5,
            _               => _currentAmountStars
        };
    }
}