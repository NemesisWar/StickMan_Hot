using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletRotateAround : MonoBehaviour
{
    public void RotateArr()
    {
        transform.DOLocalRotate(new Vector3(5, 0, 0), Time.deltaTime, RotateMode.LocalAxisAdd);
    }
}
