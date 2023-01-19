using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveState : State
{ 
    protected override IEnumerator Action(bool RunTime)
    {
        Agent.destination = Player.transform.position;
        Agent.isStopped = false;
        while (RunTime)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    protected override void AfterStopCoroutine()
    {
        Agent.isStopped = true;
    }
}
