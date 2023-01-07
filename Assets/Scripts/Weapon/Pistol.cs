using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullets _bullet;
    [SerializeField] private int _maxBullets;
    [SerializeField] private int _bullets;

    private void OnValidate()
    {
        if(_bullets>_maxBullets)
            _bullets = _maxBullets;
    }

    public override void TryShoot()
    {
        if (_bullets > 0)
        {
            _bullets--;
            Bullets bullet = Instantiate(_bullet, _shootPoint.position, _shootPoint.transform.rotation);
            bullet.Init(Timeshift);
        }

        else
        {
            TryDrop();
        }
    }
}
