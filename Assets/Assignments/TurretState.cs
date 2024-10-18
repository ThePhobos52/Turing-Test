using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretState
{
    protected TurretController _turret;
    // Start is called before the first frame update
    public TurretState(TurretController turret)
    {
        this._turret = turret;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();
}
