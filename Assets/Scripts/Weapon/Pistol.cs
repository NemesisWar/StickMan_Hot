using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pistol : Weapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullets _bullet;
    [SerializeField] private int _maxBullets;
    [SerializeField] private int _bullets;
    [SerializeField] private ParticleSystem _shootVFX;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

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
            _shootVFX.Play();
            _audioSource.PlayOneShot(_audioClip);
            Bullets bullet = Instantiate(_bullet, _shootPoint.position, _shootPoint.transform.rotation);
            bullet.Init(Timeshift);
        }

        else
        {
            TryDrop();
        }
    }

    public void AddBullets(int count)
    {
        _bullets = count;
    }
}
