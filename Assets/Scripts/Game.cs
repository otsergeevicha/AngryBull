using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private WaveFactory _waveFactory;

    private void Start()
    {
        _waveFactory.NextWave();
        Time.timeScale = 1;
    }
}