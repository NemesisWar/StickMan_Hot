using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    private Gravity _gravity;
    public Weapon Weapon => _weapon;
    [SerializeField] private Weapon _weapon;
    public int ButtelCounts;
    public bool IsMelle;
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
        _timeShift = timeShift;
        if (IsMelle != false)
        {
            ButtelCounts = Random.Range(1, 3);
        }
        _gravity = GetComponent<Gravity>();
        _gravity?.Init(_timeShift);
    }

}
