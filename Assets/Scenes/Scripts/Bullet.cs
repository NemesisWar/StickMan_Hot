using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool _timeRun;
    private TimeShift _timeShift;
    private Coroutine _coroutine;
    [SerializeField] private float _speed;

    public void Init(TimeShift timeShift)
    {
        _timeShift = timeShift;
        _timeShift.TimeIsMove += OnTimeShift;
    }

    private void OnDisable()
    {
        
    }

    private void OnTimeShift(bool timeRun)
    {
        _timeRun = timeRun;
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

    private IEnumerator Fly()
    {
        while (_timeRun)
        {
            gameObject.transform.position += transform.forward * _speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
