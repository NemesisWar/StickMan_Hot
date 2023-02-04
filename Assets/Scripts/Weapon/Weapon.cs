using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public event UnityAction dropedWeapon;
    [SerializeField] protected TimeShift Timeshift;
    [SerializeField] protected Transform DropPoint;
    [SerializeField] private Bullets _dropItem;

    public abstract void TryShoot();

    protected void TryDrop()
    {
        dropedWeapon?.Invoke();
    }

    public void Drop()
    {
        Bullets dropItem = Instantiate(_dropItem, DropPoint.position, DropPoint.transform.rotation);
        dropItem.Init(Timeshift);
        gameObject.SetActive(false);
    }
}
