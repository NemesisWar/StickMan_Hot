using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transictions
{
    protected override IEnumerator Action(bool RunTime)
    {
        while (RunTime)
        {
            if(Contact.PlayerVisible == false)
            {
                NeedTransit = true;
            }
            yield return new WaitForEndOfFrame();
        }

    }
}
