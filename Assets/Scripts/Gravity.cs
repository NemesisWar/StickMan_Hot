using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _yPower;
    [SerializeField] private float _gravity;
    private Rigidbody _rigibody;
    private TimeShift _timeShift;
    private bool RunTime;
    private Coroutine _coroutine;


    public void GravityPower()
    {
        transform.position+=new Vector3(0, _yPower,0)*Time.deltaTime;
        _yPower -= _gravity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _yPower = 0;
        if (_rigibody != null)
            _rigibody.useGravity = true;
        StopCoroutine(_coroutine);
        _coroutine = null;
        AfterStopCoroutine();
        enabled = false;
    }

    public void Init(TimeShift timeShift)
    {
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.useGravity = false;
        _timeShift = timeShift;
        _timeShift.TimeIsMove += TimeRun;
    }

    private void OnDisable()
    {
        if (_timeShift != null)
            _timeShift.TimeIsMove -= TimeRun;
    }

    private void TimeRun(bool runTime)
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
                AfterStopCoroutine();
            }
        }
    }

    private IEnumerator Action(bool runTime)
    {
        while (runTime)
        {
            GravityPower();
            yield return new WaitForEndOfFrame();
        }
    }

    private void AfterStopCoroutine()
    {
    }
}
