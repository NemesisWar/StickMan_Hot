using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleBullet : Bullets
{
    [SerializeField] private BulletRotateAround _bulletRotateAround;

    protected override IEnumerator Fly()
    {
        while (TimeRun)
        {
            gameObject.transform.position += transform.forward * Speed * Time.deltaTime;
            _bulletRotateAround.RotateArr();
            yield return new WaitForEndOfFrame();
        }
    }
}
