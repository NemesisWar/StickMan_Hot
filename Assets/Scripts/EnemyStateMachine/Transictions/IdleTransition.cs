using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : Transictions
{
    protected override IEnumerator Action(bool RunTime)
    {
        if (Player == null)
        {
            NeedTransit = true;
        }
        yield return new WaitForEndOfFrame();
    }
}
