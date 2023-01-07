using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Player _player;
    private Enemy _enemy;
    private State _currentState;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _player = _enemy.GetComponent<Player>();
    }

    private void Reset(State startstate)
    {
        _currentState = startstate;
        if (_currentState != null)
            _currentState.Enter(_player);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;
        _currentState.Enter(_player);
    }

    private void Update()
    {
        if(_currentState == null)
        {
            return;
        }

        State nextState = _currentState.GetNextState();
        if (_currentState != null)
        {
            Transit(nextState);
        }
    }
}
