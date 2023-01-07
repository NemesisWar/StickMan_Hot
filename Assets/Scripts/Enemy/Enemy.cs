using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TimeShift _timeShift;
    public event UnityAction<bool> CanMove;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        _timeShift.TimeIsMove +=cxt=>CanMove?.Invoke(cxt);
    }

    private void OnDisable()
    {
        _timeShift.TimeIsMove -= cxt => CanMove?.Invoke(cxt);
    }
}
