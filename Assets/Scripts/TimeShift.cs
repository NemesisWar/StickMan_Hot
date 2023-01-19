using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeShift : MonoBehaviour
{
    public bool TimeRun { get; private set; }
    public Player Player { get; private set; }
    public event UnityAction<bool> TimeIsMove;
    [SerializeField] private PlayerMove _playerMove;

    private void OnEnable()
    {
        Player = _playerMove.gameObject.GetComponent<Player>();
        Cursor.visible = false;
        _playerMove.IsMove += FlowTime;
    }

    private void OnDisable()
    {
        _playerMove.IsMove -= FlowTime;
    }

    private void FlowTime(bool timeRun)
    {
        TimeRun = timeRun;
        TimeIsMove?.Invoke(timeRun);
    }
}
