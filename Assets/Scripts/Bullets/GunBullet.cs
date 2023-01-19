using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullets
{
    protected override IEnumerator Fly()
    {
        while (TimeRun)
        {
            LifeTime+=Time.deltaTime;
            gameObject.transform.position += transform.forward * Speed * Time.deltaTime;
            if (LifeTime >= MaxLifeTime) 
            { 
                Destroy(gameObject);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
