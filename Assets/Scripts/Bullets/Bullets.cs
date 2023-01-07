using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
    protected bool TimeRun;
    private TimeShift _timeShift;
    private Coroutine _coroutine;
    [SerializeField] protected float Speed;

    public void Init(TimeShift timeShift)
    {
        _timeShift = timeShift;
        _timeShift.TimeIsMove += OnTimeShift;
    }

    private void OnDisable()
    {
        _timeShift.TimeIsMove -= OnTimeShift;
    }

    private void OnTimeShift(bool timeRun)
    {
        TimeRun = timeRun;
        if (timeRun)
        {
            _coroutine = StartCoroutine(Fly());
        }
        else
        {
            StopCoroutine(Fly());
            _coroutine = null;
        }
    }

    protected abstract IEnumerator Fly();
}
