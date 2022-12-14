using System.Collections.Generic;
using UnityEngine;

public class VillianSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _camera;
    [SerializeField] private WaveFactory _waveFactory;

    private List<Villian> _villians;
    private int _currentIndex = 0;
    private float[] _spawnPoints = {18.5f, 78f, 130f};

    private void OnEnable()
    {
        _waveFactory.WaveChanged += OnWaveChanged;
    }

    private void OnDisable()
    {
        _waveFactory.WaveChanged -= OnWaveChanged;
    }

    private void OnWaveChanged()
    {
        DestroyerVilliants();
        CreateVilliants();
        Placement();
    }

    public void OffVisible()
    {
        if(_villians == null)
            return;

        foreach(var villian in _villians)
            villian.gameObject.SetActive(false);
    }

    private void DestroyerVilliants()
    {
        _currentIndex = 0;

        if(_villians == null)
            return;

        foreach(var villian in _villians)
            Destroy(villian.gameObject);
    }

    private void Placement()
    {
        foreach(var villian in _villians)
        {
            villian.Init(new Vector3(11f, .3f, _spawnPoints[_currentIndex]), _player.transform, _camera);
            _currentIndex++;
        }
    }

    private void CreateVilliants()
    {
        _villians = _waveFactory.CreateVillians();
    }
}