using DG.Tweening;
using UnityEngine;

public class EmojiControl : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private ParticleSystem _particleSilly;
    [SerializeField] private ParticleSystem _particleHappy;
    [SerializeField] private ParticleSystem _particleAngry;
    [SerializeField] private ParticleSystem _particleStars;
    [SerializeField] private ParticleSystem _particleFireTail;

    private Vector3 _savedScaleTrail;
    
    private void Start()
    {
        _particleSilly.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _playerMovement.SpeedChanged += ChangerEmoji;
    }

    private void OnDisable()
    {
        _playerMovement.SpeedChanged -= ChangerEmoji;
    }

    private void ChangerEmoji(float speed)
    {
        if(speed < 15)
        {
            _particleStars.gameObject.SetActive(false);   
            _particleFireTail.gameObject.SetActive(false);
            _particleHappy.gameObject.SetActive(true);
        }

        if(speed > 15)
        {
            _particleHappy.gameObject.SetActive(false);
            _particleStars.gameObject.SetActive(true);   
            _particleFireTail.gameObject.SetActive(true);
            Invoke(nameof(TimeLifeTrail), .8f);
        }
    }

    private void TimeLifeTrail()
    {
        _particleFireTail.transform.DOScale(0, .2f).SetEase(Ease.Linear).OnComplete(SetTrail);
    }

    private void SetTrail()
    {
        _particleFireTail.transform.localScale = new Vector3(2f, 2f, 2f);
    }
}