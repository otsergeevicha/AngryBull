using UnityEngine;

public class WindowWin : MonoBehaviour
{
    [SerializeField] private CelebrationBull _celebrationBull;
    [SerializeField] private Levels _menuLevels;
    [SerializeField] private WaveFactory _waveFactory;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _payNextButton;

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
        _menuLevels.gameObject.SetActive(true);
    }

    public void OnCelebrationBull()
    {
        _celebrationBull.gameObject.SetActive(true);
        _menuLevels.gameObject.SetActive(false);
    }

    private void ChangeButton()
    {
        _nextButton.gameObject.SetActive(false);
        _payNextButton.gameObject.SetActive(true);
    }
}