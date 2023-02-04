using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Weapon
{
    public override void TryShoot()
    {
        TryDrop();
    }
}
