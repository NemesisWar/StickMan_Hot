using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class WeaponControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public Weapon CurrentWeapon => _currentWeapon;
    private Weapon _currentWeapon;
    [SerializeField] private Weapon _startWeapon;
    private PlayerShoot _playerShoot;
    private List<Weapon> _weapons = new List<Weapon>();
    private Coroutine _coroutine;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerShoot = GetComponentInParent<PlayerShoot>();
        _weapons.AddRange(GetComponentsInChildren<Weapon>());
        DisableAllWeapons(_weapons);
        if (_startWeapon != null)
        {
            _animator.SetInteger("Weapon", GetWeaponIndex(_startWeapon));
            EnableWeapon(_startWeapon);
        }
    }

    private void DisableAllWeapons(List<Weapon> weapons)
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    public void EnableWeapon(Weapon currentweapon)
    {
        _currentWeapon = currentweapon;
        foreach(Weapon weapon in _weapons)
        {
            if(_currentWeapon == weapon)
            {
                weapon.gameObject.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        _playerShoot.TryShoot += OnShoot;
        foreach(Weapon weapon in _weapons)
        {
            weapon.dropedWeapon += WeaponDropedAnimationStart;
        }
    }

    private void OnDisable()
    {
        _playerShoot.TryShoot -= OnShoot;
        foreach (Weapon weapon in _weapons)
        {
            weapon.dropedWeapon -= WeaponDropedAnimationStart;
        }
    }

    private void OnShoot()
    {
        if(_currentWeapon != null)
        {
            _currentWeapon.TryShoot();
        }
    }

    public void TakeWeapon(Item item)
    {
        foreach(Weapon weapon in _weapons)
        {
            Debug.Log($"{weapon}b{item.Weapon}");
            if (weapon.name == item.Weapon.name)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                    _coroutine = null;
                }
                _coroutine = StartCoroutine(MoveItem(weapon, item));
            }
        }
    }

    private IEnumerator MoveItem(Weapon weapon, Item item)
    {
        _animator.SetInteger("Weapon", GetWeaponIndex(weapon));
        item.gameObject.transform.DOMove(weapon.gameObject.transform.position, 0.5f);
        item.gameObject.transform.DORotate(weapon.gameObject.transform.position, 0.7f);
        while (Vector3.Distance(weapon.transform.position, item.transform.position)>=0.4f)
        {
            yield return new WaitForEndOfFrame();
        }
        ItemTaked(weapon,item);
    }

    private void ItemTaked(Weapon weapon, Item item)
    {
        _audioSource.PlayOneShot(weapon.TakeAudioClip);
        if(item.IsMelle == false)
        {
            if(weapon is Pistol)
            {
                Pistol pistol = (Pistol)weapon;
                pistol.AddBullets(item.ButtelCounts);
            }
        }
        Destroy(item.gameObject);
        EnableWeapon(weapon);
    }

    private void WeaponDropedAnimationStart() 
    {
        _animator.SetBool("Droped", true);
    }

    public void WeaponDroped()
    {
        _currentWeapon.Drop();
        _currentWeapon = null;
        _animator.SetBool("Droped", false);
        _animator.SetInteger("Weapon", 0);
    }

    private int GetWeaponIndex(Weapon weapon)
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if(weapon == _weapons[i])
            {
                return i+1;
            }
        }

        return 0;
    }
}
