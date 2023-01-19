using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transictions
{
    protected override IEnumerator Action(bool RunTime)
    {
        while (RunTime)
        {
            if (Contact.PlayerVisible == true)
            {
                NeedTransit = true;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
