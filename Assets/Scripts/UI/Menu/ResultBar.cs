using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultBar : MonoBehaviour
{
    [SerializeField] private BarView _barView;
    [SerializeField] private TimerLevelView _timerLevel;

    [SerializeField] private Image _slider;
    [SerializeField] private TMP_Text _textCountStar;

    public event Action<float> Changed;

    private float _result;
    private Coroutine _coroutine;

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
        Changed?.Invoke(_result);
        Render();
    }

    private void Render()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveSlider());
    }

    private IEnumerator MoveSlider()
    {
        _slider.fillAmount = Mathf.MoveTowards(_slider.fillAmount, _result, 2f);
        AddStar();
        yield return new WaitForFixedUpdate();
    }

    private void AddStar()
    {
        _textCountStar.text = _slider.fillAmount switch
        {
            > 0f and < .2f  => 1.ToString(),
            > .2f and < .4f => 2.ToString(),
            > .4f and < .6f => 3.ToString(),
            > .6f and < .8f => 4.ToString(),
            > .8f           => 5.ToString(),
            _               => _textCountStar.text
        };
    }
}