using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedPushButton : PushButton
{
    public bool locked = true;

    public override void OnSelect()
    {
        if (locked)
            return;
        onPush?.Invoke();
    }

    public void ToggleLock(bool status)
    {
        locked = status;
    }
}
