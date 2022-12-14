using UnityEngine;

public class LevelDataStars : MonoBehaviour
{
    [SerializeField] private ResultBar _resultBar;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private Level[] _levels;
    [SerializeField] private SaveLoad _saveLoad;

    private float _savedResult = 0;
    private int _currentAmountStars = 0;
    private int _currentIndexScene = 0;

    private void OnEnable()
    {
        _resultBar.Changed += RenderStar;
        _sceneController.ChangedScene += GetCurrentScene;
    }

    private void OnDisable()
    {
        _resultBar.Changed -= RenderStar;
        _sceneController.ChangedScene -= GetCurrentScene;
    }

    private void RenderStar(float result)
    {
        if(_savedResult > result)
            return;

        _savedResult = result;
        NormalizationCountStars();
        _levels[_currentIndexScene].RenderStars(_saveLoad.ReadStarData(_currentAmountStars));
        _saveLoad.AddStarsData(_currentIndexScene, _currentAmountStars);
    }

    private void GetCurrentScene(int currentNumber)
    {
        _currentIndexScene = currentNumber;
    }
    
    private void NormalizationCountStars()
    {
        _currentAmountStars = _savedResult switch
        {
            > .2f and < .4f => 0,
            > .4f and < .6f => 1,
            > .6f and < .8f => 2,
            > .8f and < 1f  => 3,
            > 1f            => 4,
            _               => _currentAmountStars
        };
    }
}