using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeShift : MonoBehaviour
{
    public event UnityAction<bool> TimeIsMove;
    [SerializeField] private PlayerMove _playerMove;

    private void OnEnable()
    {
        _playerMove.IsMove += FlowTime;
    }

    private void OnDisable()
    {
        _playerMove.IsMove -= FlowTime;
    }

    private void FlowTime(bool timeRun)
    {
        TimeIsMove?.Invoke(timeRun);
    }
}
