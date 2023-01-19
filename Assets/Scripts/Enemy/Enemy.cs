using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public TimeShift TimeShift => _timeShift;
    public Player Player => _player;
    private Player _player;
    [SerializeField] private TimeShift _timeShift;
    public event UnityAction<bool> CanMove;

    public void Init(TimeShift timeShift)
    {
        Debug.Log("Init");
        _timeShift = timeShift;
        _player = timeShift.Player;
    }

    private void Awake()
    {

    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        _timeShift.TimeIsMove +=cxt=>CanMove?.Invoke(cxt);
    }

    private void OnDisable()
    {
        _timeShift.TimeIsMove -= cxt => CanMove?.Invoke(cxt);
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
