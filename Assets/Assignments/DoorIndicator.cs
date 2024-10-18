using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorIndicator : MonoBehaviour
{
    public UnityEvent UnlockDoorEvent;
    public UnityEvent LockDoorEvent;

    public void UnlockDoor()
    {
        UnlockDoorEvent.Invoke();
    }

    public void LockDoor()
    {
        LockDoorEvent.Invoke();
    }
}
