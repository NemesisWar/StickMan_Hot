using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletRotateAround : MonoBehaviour
{
    [SerializeField] private float _xRotateSpeed;
    public void RotateArr()
    {
        transform.DOLocalRotate(new Vector3(_xRotateSpeed, 0, 0), Time.deltaTime, RotateMode.LocalAxisAdd);
    }
}
