using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Beacon : MonoBehaviour
{
    [SerializeField] private TriggerBeacon _triggerBeacon;

    private const float RateStep = .25f;

    private Light _light;
    private Coroutine _coroutine;
    private bool _isViewPlayer = false;
    private float _maxValueIntensity = 8;
    private float _minValueIntensity = 0;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void OnEnable()
    {
        _triggerBeacon.Entered += Play;
        _triggerBeacon.Leaving += Stop;
    }

    private void OnDisable()
    {
        _triggerBeacon.Entered -= Play;
        _triggerBeacon.Leaving -= Stop;
    }
    
    private void Play()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _isViewPlayer = true;
        _coroutine = StartCoroutine(JobBeacon());
    }

    private void Stop()
    {
        _isViewPlayer = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator JobBeacon()
    {
        var waitForSeconds = new WaitForSeconds(RateStep);

        while(_isViewPlayer)
        {
            _light.intensity = _maxValueIntensity;
            yield return waitForSeconds;

            _light.intensity = _minValueIntensity;
            yield return waitForSeconds;
        }
    }
}