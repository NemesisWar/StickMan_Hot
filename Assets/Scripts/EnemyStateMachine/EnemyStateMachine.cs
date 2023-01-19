using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Enemy _enemy;
    private State _currentState;
    [SerializeField] private State _startState;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        if (_enemy != null)
        {
            Debug.Log("Enemy is not null");
            Reset(_startState);
        }
    }

    private void Reset(State startstate)
    {
        _currentState = startstate;
        if (_currentState != null)
            _currentState.Enter(_enemy);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;
        _currentState.Enter(_enemy);
    }

    private void Update()
    {
        if(_currentState == null)
        {
            return;
        }

        State nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }
}
