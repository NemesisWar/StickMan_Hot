using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected TimeShift Timeshift;
    [SerializeField] protected Transform DropPoint;
    [SerializeField] private Bullets _dropItem;

    public abstract void TryShoot();

    protected void TryDrop()
    {
        Bullets dropItem = Instantiate(_dropItem, DropPoint.position, DropPoint.transform.rotation);
        dropItem.Init(Timeshift);
    }
}
