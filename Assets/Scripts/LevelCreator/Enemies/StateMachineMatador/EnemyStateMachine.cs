using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyStateRun _firstEnemyState;
    [SerializeField] private List<EnemyTransition> _transitions;
    [SerializeField] private EnemyTransitionDie _transitionDie;
    [SerializeField] private EnemyStateDie _stateDie;

    private EnemyTransition _enemyTransition;
    private EnemyState _enemyState;
    private EnemyState _currentEnemyState;

    private void Start()
    {
        _enemyState = _firstEnemyState;
        _currentEnemyState = _firstEnemyState;
    }

    private void Update()
    {
        NeedTransit();
        Transit();
    }

    private void OnEnable()
    {
        _transitionDie.TransitionDied += StartDie;
    }

    private void OnDisable()
    {
        _transitionDie.TransitionDied -= StartDie;
    }

    private void StartDie()
    {
        _currentEnemyState = _stateDie;
        _stateDie.enabled = true;
    }
    
    public EnemyState NeedTransit() => (from transition in _transitions where transition.GetState() != null select transition.GetState()).FirstOrDefault();

    private void Transit()
    {
        if(_enemyState == NeedTransit() || _enemyState == null) return;

        _enemyState.ExitBehaviour(_enemyState);
        _currentEnemyState = NeedTransit();
        _enemyState.EnterBehavior(_currentEnemyState);
    }
}