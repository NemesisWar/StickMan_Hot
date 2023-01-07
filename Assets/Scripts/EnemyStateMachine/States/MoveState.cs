using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected override IEnumerator Action(bool RunTime)
    {
        yield return new WaitForEndOfFrame();
    }
}
