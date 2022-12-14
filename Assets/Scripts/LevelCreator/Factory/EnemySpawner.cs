using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _camera;
    [SerializeField] private WaveFactory _waveFactory;

    private const float PositionY = 0f;
    private const int BorderSpawn = 7;
    private const int MinDistanceSpawn = 0;
    private const int MaxDistanceSpawn = 135;

    private List<Enemy> _enemies;

    private void OnEnable()
    {
        _waveFactory.WaveChanged += OnWaveChanged;
    }

    private void OnDisable()
    {
        _waveFactory.WaveChanged -= OnWaveChanged;
    }

    public void OffVisible()
    {
        if(_enemies == null)
            return;

        foreach(var enemy in _enemies)
            enemy.gameObject.SetActive(false);
    }

    private void DestroyerEnemies()
    {
        if(_enemies == null)
            return;

        foreach(var enemy in _enemies)
            Destroy(enemy.gameObject);
    }

    private void OnWaveChanged()
    {
        DestroyerEnemies();
        CreateEnemies();
        Placement();
    }

    private void CreateEnemies()
    {
        _enemies = _waveFactory.CreateEnemies();
    }

    private void Placement()
    {
        foreach(Enemy enemy in _enemies)
        {
            enemy.Init(
                new Vector3(Random.Range(-BorderSpawn, BorderSpawn), PositionY,
                    Random.Range(MinDistanceSpawn, MaxDistanceSpawn)), _player, _camera);
        }
    }
}