using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transictions : MonoBehaviour
{
    public State TargetState => _targetState;
    [SerializeField] private State _targetState;
    [SerializeField] protected VisibleContact Contact;
    protected Player Player;
    protected Enemy Enemy;
    private Coroutine _coroutine;
    protected bool RunTime;
    public bool NeedTransit { get; protected set; }

    public void Init(Enemy enemy)
    {
       Enemy = enemy;
       Player = enemy.Player;
    }

    private void OnEnable()
    {
        NeedTransit = false;
        Enemy.CanMove += OnCanMove;
    }

    private void OnDisable()
    {
        Enemy.CanMove -= OnCanMove;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
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
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    protected abstract IEnumerator Action(bool RunTime);
}
