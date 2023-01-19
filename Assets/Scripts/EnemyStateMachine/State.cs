using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    protected Animator Animator;
    protected NavMeshAgent Agent;
    [SerializeField] private List<Transictions> _transictions;
    protected Player Player;
    protected Enemy Enemy;
    private Coroutine _coroutine;
    protected bool RunTime;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        Enemy.CanMove += OnCanMove;
    }

    private void OnDisable()
    {
        Enemy.CanMove -= OnCanMove;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            AfterStopCoroutine();
        }
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
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
                AfterStopCoroutine();
            }
        }
    }

    protected abstract void AfterStopCoroutine();

    protected abstract IEnumerator Action(bool RunTime);

    public void Enter(Enemy enemy)
    {
        if(enabled == false)
        {
            Enemy = enemy;
            Player = Enemy.Player;
            enabled = true;
            foreach(var transiction in _transictions)
            {
                transiction.Init(Enemy);
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
