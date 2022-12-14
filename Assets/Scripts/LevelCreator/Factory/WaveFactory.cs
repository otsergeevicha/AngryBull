using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WaveFactory : MonoBehaviour
{
    [SerializeField] private EnemiesFactory _enemiesFactory;
    [SerializeField] private OutdoorItemsFactory _outdoorItemsFactory;
    [SerializeField] private VillianFactory _villianFactory;


    [SerializeField] private List<Wave> _waves;

    public event Action WaveChanged;
    public event Action OnLastWave;

    private int _currentWaveIndex = -1;

    private Wave Wave => _waves[_currentWaveIndex];
    public string NameWave => _waves[_currentWaveIndex].Name;

    private void Update()
    {
        if(_currentWaveIndex != _waves.Count - 1)
            return;

        OnLastWave?.Invoke();
    }
    
    public void NextWave()
    {
        if(_currentWaveIndex == _waves.Count - 1)
            _currentWaveIndex = -1;

        _currentWaveIndex++;
        WaveChanged?.Invoke();
    }

    public List<Villian> CreateVillians()
    {
        List<Villian> villians = _villianFactory.Create(Wave.Villians, Wave.VillianCapacity);

        return villians;
    }

    public List<Enemy> CreateEnemies()
    {
        List<Enemy> enemies = _enemiesFactory.Create(Wave.EnemyPrefabs, Wave.EnemyCapacity);

        foreach(Enemy enemy in enemies)
        {
            enemy.SafePoints = Wave.SafePoints;
            enemy.Target = Wave.TargetEnemy;
        }

        return enemies;
    }

    public List<OutdoorItems> CreateOutdoorItems()
    {
        return _outdoorItemsFactory.Create(Wave.OutdoorItemsPrefabs, Wave.OutdoorItemsCapacity);
    }

    public int GetCountEnemies()
    {
        int capacitySpawnedEnemies = 0;

        foreach(Wave wave in _waves)
        {
            capacitySpawnedEnemies += wave.EnemyCapacity;
            capacitySpawnedEnemies += wave.VillianCapacity;
        }

        return capacitySpawnedEnemies;
    }
}