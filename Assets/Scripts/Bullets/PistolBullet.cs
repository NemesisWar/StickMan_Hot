using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : Bullets
{
    [SerializeField] private float _rotateSpeed;
    protected override IEnumerator Fly()
    {
        while (TimeRun)
        {
            gameObject.transform.position += transform.forward * Speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
