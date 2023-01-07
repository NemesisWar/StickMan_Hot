using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    private PlayerShoot _playerShoot;
    private List<Weapon> _weapons = new List<Weapon>();

    private void Awake()
    {
        _playerShoot = GetComponentInParent<PlayerShoot>();
        _weapons.AddRange(GetComponentsInChildren<Weapon>());
    }

    private void OnEnable()
    {
        _playerShoot.TryShoot += OnShoot;
    }

    private void OnDisable()
    {
        _playerShoot.TryShoot -= OnShoot;
    }

    private void OnShoot()
    {
        _currentWeapon.TryShoot();
    }

}
