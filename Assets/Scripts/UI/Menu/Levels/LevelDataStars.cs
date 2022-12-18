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

    private void NormalizationCountStars()
    {
        if(_savedResult < _result)
            _savedResult = _result;

        _currentAmountStars = Mathf.FloorToInt(Mathf.Lerp(0, 5f, _result));
    }

    private void OnChangeView()
    {
        _result = _barView.GetProgress();
        NormalizationCountStars();
        _saveLoad.SaveStarsData(_sceneController.CurrentScene, _currentAmountStars);
    }
}