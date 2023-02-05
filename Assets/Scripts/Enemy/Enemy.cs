using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> Die;
    public TimeShift TimeShift => _timeShift;
    public Player Player => _player;
    private Player _player;
    private TimeShift _timeShift;
    [SerializeField] private Item _dropedWeapon;
    public event UnityAction<bool> CanMove;

    public void Init(TimeShift timeShift)
    {
        _timeShift = timeShift;
        _player = timeShift.Player;
    }

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

    public void TakeDamage()
    {
        if (_dropedWeapon != null)
        {
            Item item = Instantiate(_dropedWeapon,transform.position,Quaternion.identity);
            item.Init(_timeShift);
        }
        Die?.Invoke(this);
        Destroy(gameObject);
    }
}
