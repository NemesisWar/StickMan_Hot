using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public abstract class Bullets : MonoBehaviour
{
    protected bool TimeRun;
    private TimeShift _timeShift;
    private Coroutine _coroutine;
    [SerializeField] protected float Speed;
    [SerializeField] protected float MaxLifeTime;
    protected float LifeTime = 0;

    public void Init(TimeShift timeShift)
    {
        _timeShift = timeShift;
        _timeShift.TimeIsMove += OnTimeShift;
        OnTimeShift(_timeShift.TimeRun);
    }

    private void OnDisable()
    {
        _timeShift.TimeIsMove -= OnTimeShift;
        if (_coroutine != null)
        {
            StopCoroutine(Fly());
            _coroutine = null;
        }
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
            if(_coroutine != null)
            {
                StopCoroutine(Fly());
                _coroutine = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Player_Dead");
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("DESTROY_BULL");
            Destroy(gameObject);
        }
    }

    protected abstract IEnumerator Fly();
}
