using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public Weapon Weapon => _weapon;
    [SerializeField] private Weapon _weapon;
    public int ButtelCounts;
    public bool IsMelle;
    private Rigidbody _rigibody;
    private Coroutine _coroutine;
    private bool RunTime;
    private TimeShift _timeShift;

    private void OnValidate()
    {
        if (IsMelle)
        {
            ButtelCounts = 0;
        }
    }

    public void Init(TimeShift timeShift)
    {
        _rigibody = GetComponent<Rigidbody>();
        _timeShift = timeShift;
        _timeShift.TimeIsMove += TimeRun;
        _rigibody.AddForce(new Vector3(1, 1, 0), ForceMode.Impulse);
        if (IsMelle != false)
        {
            ButtelCounts = Random.Range(1, 3);
        }
    }

    private void OnDisable()
    {
        if(_timeShift!=null)
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
        _rigibody.isKinematic = false;
        while (runTime)
        {          
            yield return new WaitForEndOfFrame();
        }
    }

    private void AfterStopCoroutine()
    {
        _rigibody.isKinematic = true;
    }
}
