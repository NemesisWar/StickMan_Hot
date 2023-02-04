using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropItemPlayer : MonoBehaviour
{
    [SerializeField] private WeaponControl _weaponControl;

    public void DropPointAnimation()
    {
        Debug.Log("DROPED");
        _weaponControl.WeaponDroped();
    }
}
