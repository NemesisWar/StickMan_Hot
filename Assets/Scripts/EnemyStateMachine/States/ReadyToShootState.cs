using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToShootState : State
{
    protected override IEnumerator Action(bool RunTime)
    {
        Animator.SetBool("ReadyToShoot",RunTime);
        yield return null;
    }

    protected override void AfterStopCoroutine()
    {
        
    }
}
