using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private EnemyStateFear _enemyStateFear;
    [SerializeField] private EnemyStateDie _enemyStateDie;

    public event Action<Player> WokeUp;
    public Transform[] SafePoints;
    public Transform Target;

    private Player _player;

    private float _speed = 0;
    private int _price = 20;

    public Transform CameraPoint{get;private set;}
    public bool Alive{get;private set;} = false;

    private void Awake()
    {
        _meshRenderer.enabled = false;
        Alive = false;
    }

    private void OnEnable()
    {
        _enemyStateFear.Feared += ChangeTarget;
        _enemyStateDie.Died += PayDie;
    }

    private void OnDisable()
    {
        _enemyStateFear.Feared -= ChangeTarget;
        _enemyStateDie.Died -= PayDie;
    }

    private void FixedUpdate()
    {
        _enemyMovement.Move(Target, _speed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(!collision.TryGetComponent(out ObserverLevel _))
            return;

        Alive = true;
        _meshRenderer.enabled = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if(!collision.TryGetComponent(out ObserverLevel _))
            return;

        _meshRenderer.enabled = false;
    }

    public void Init(Vector3 spawnPoint, Player player, Transform cameraPoint)
    {
        CameraPoint = cameraPoint;
        _player = player;
        WokeUp?.Invoke(_player);
        transform.position = spawnPoint;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public void ChangeSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    private void ChangeTarget(Transform newTarget)
    {
        Target = newTarget;
    }

    private void PayDie()
    {
        _player.ApplyMoney(_price);
        _player.IncreaseSpeed();
    }
}