using System.Collections.Generic;
using UnityEngine;

public class OutdoorItemsSpawner : MonoBehaviour
{
    [SerializeField] private WaveFactory _waveFactory;
    
    private const int BorderSpawn = 6;
    private const int MinDistanceSpawn = 5;
    private const int MaxDistanceSpawn = 140;
    private const float PositionY = .35f;
    
    private List<OutdoorItems> _outdoorItems;
    private Vector3 _spawnPoint;

    private void OnEnable()
    {
        _waveFactory.WaveChanged += OnWaveChanged;
    }

    private void OnDisable()
    {
        _waveFactory.WaveChanged -= OnWaveChanged;
    }

    private void DestroyerOutdoorItems()
    {
        if(_outdoorItems == null)
            return;

        foreach(OutdoorItems outdoorItem in _outdoorItems)
        {
            Destroy(outdoorItem.gameObject);
        }
    }
    
    private void OnWaveChanged()
    {
        DestroyerOutdoorItems();
        CreateOutdoorItems();
        Placement();
    }

    private void CreateOutdoorItems()
    {
        _outdoorItems = _waveFactory.CreateOutdoorItems();
    }
    
    private void Placement()
    {
        foreach(OutdoorItems outdoor in _outdoorItems)
        {
            outdoor.Init(new Vector3(Random.Range(-BorderSpawn, BorderSpawn), PositionY, Random.Range(MinDistanceSpawn, MaxDistanceSpawn)));
        }
    }
}
