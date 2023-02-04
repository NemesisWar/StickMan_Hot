using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveState : State
{ 
    protected override IEnumerator Action(bool RunTime)
    {
        Agent.destination = Player.transform.position;
        Animator.speed = 1;
        Agent.isStopped = false;
        Animator.SetBool("Walk", true);
        Animator.SetBool("ReadyToShoot", false);
        while (RunTime)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    protected override void AfterStopCoroutine()
    {
        Animator.speed = 0;
        Agent.isStopped = true;
    }
}
