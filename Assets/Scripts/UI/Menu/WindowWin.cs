using UnityEngine;

public class WindowWin : MonoBehaviour
{
    [SerializeField] private CelebrationBull _celebrationBull;
    [SerializeField] private Levels _menuLevels;
    [SerializeField] private WaveFactory _waveFactory;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _payNextButton;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private GameObject _panelMenuLevel;
    [SerializeField] private GameObject _panelBull;

    [SerializeField] private Level[] _levels;

    private void OnEnable()
    {
        _waveFactory.OnLastWave += ChangeButton;
    }

    private void OnDisable()
    {
        _waveFactory.OnLastWave -= ChangeButton;
    }

    public void OnMenuLevel()
    {
        _celebrationBull.gameObject.SetActive(false);
        _panelBull.gameObject.SetActive(false);
        _levels[_sceneController.CurrentScene].RenderStars(_saveLoad.ReadStarData(_sceneController.CurrentScene));
        _panelMenuLevel.gameObject.SetActive(true);
        _menuLevels.gameObject.SetActive(true);

        for(int i = 0; i < _levels.Length; i++)
            _levels[i].RenderStars(_saveLoad.ReadStarData(i));
    }

    public void OnCelebrationBull()
    {
        _panelBull.gameObject.SetActive(true);
        _celebrationBull.gameObject.SetActive(true);
        _panelMenuLevel.gameObject.SetActive(false);
        _menuLevels.gameObject.SetActive(false);
    }

    private void ChangeButton()
    {
        _nextButton.gameObject.SetActive(false);
        _payNextButton.gameObject.SetActive(true);
    }
}