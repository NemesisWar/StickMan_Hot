using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullets
{
    protected override IEnumerator Fly()
    {
        while (TimeRun)
        {
            gameObject.transform.position += transform.forward * Speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
