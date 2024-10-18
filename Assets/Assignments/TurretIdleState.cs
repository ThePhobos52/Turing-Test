using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TurretIdleState : TurretState
{
    public TurretIdleState(TurretController turret) : base(turret)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Entering idle state...");
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting idle state...");
    }

    public override void OnStateUpdate()
    {
        if(Physics.BoxCast(_turret.turretBarrel.position, _turret.turretBarrel.transform.localScale * 0.2f, _turret.turretBarrel.forward, out RaycastHit hit, _turret.turretBarrel.rotation, _turret.playerCheckDistance))
        {
            _turret.laser.SetPosition(1, hit.point);

            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player found!");
                _turret.player = hit.transform;
                //Move to a new state
                //Move to the attack state
                _turret.ChangeState(new TurretAttackState(_turret));
            }

            return;
        }

        _turret.laser.SetPosition(1, _turret.endPoint);
    }
}
