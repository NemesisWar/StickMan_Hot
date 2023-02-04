using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemTaked : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private WeaponControl _weaponControl;
    private Ray _ray;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.scaledPixelHeight / 2, 0));
        if(Physics.Raycast(_ray,out RaycastHit hit, _distance))
        {
            if (hit.transform.gameObject.TryGetComponent(out DymanicButton dymanicButton))
            {
                dymanicButton.ShowedButton();
            }
        }
    }

    public void TryTake()
    {
        _ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.scaledPixelHeight / 2, 0));
        if (Physics.Raycast(_ray, out RaycastHit hit, _distance))
        {
            if (hit.transform.gameObject.TryGetComponent(out Item item) && _weaponControl.CurrentWeapon==null)
            {
                _weaponControl.TakeWeapon(item);
            }
        }
    }
}
