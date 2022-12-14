using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveFactory _waveFactory;
    [SerializeField] private Slider _slider;

    private float _currentCountEnemy = 0;
    private float _maxCountEnemy;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider.value = 0;
        _maxCountEnemy = _waveFactory.GetCountEnemies();
    }

    private void OnEnable()
    {
        _player.WalletChanged += Render;
    }

    private void OnDisable()
    {
        _player.WalletChanged -= Render;
    }

    public float GetProgress()
    {
        float progress = _slider.value;
        return progress;
    }
    
    private void Render(float countView)
    {
        _currentCountEnemy += countView;
        _currentCountEnemy /= _maxCountEnemy;

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveSlider());
    }

    private IEnumerator MoveSlider()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _currentCountEnemy, .5f);
        yield return new WaitForFixedUpdate();
    }
}