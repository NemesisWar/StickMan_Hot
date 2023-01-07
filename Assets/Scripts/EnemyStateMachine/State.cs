using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[ RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    [SerializeField] private List<Transictions> _transictions;
    protected Player Player;
    private Enemy _enemy;
    private Coroutine _coroutine;
    protected bool RunTime;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.CanMove += OnCanMove;
    }

    private void OnDisable()
    {
        _enemy.CanMove -= OnCanMove;
    }

    private void OnCanMove(bool runTime)
    {
        RunTime = runTime;
        if (RunTime == true)
        {
            _coroutine = StartCoroutine(Action(RunTime));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    protected abstract IEnumerator Action(bool RunTime);

    public void Enter(Player player)
    {
        if(enabled == false)
        {
            Player = player;
            enabled = true;
            foreach(var transiction in _transictions)
            {
                transiction.Init(Player);
                transiction.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach(var transiction in _transictions)
            {
                transiction.enabled = false;
            }
            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transiction in _transictions)
        {
            if (transiction.NeedTransit == true)
            {
                return transiction.TargetState;
            }

        }
        return null;
    }
}
