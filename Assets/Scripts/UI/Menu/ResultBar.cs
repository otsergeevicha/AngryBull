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
        _textCountStar.text = Mathf.FloorToInt(Mathf.Lerp(0, 5f, _result)).ToString();
    }
}