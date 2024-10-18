using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    Health playerHealth;
    float damage = 20f;
    public TurretAttackState(TurretController turret) : base(turret)
    {
        playerHealth = turret.player.GetComponent<Health>();
    }

    public override void OnStateEnter()
    {
        Debug.Log("Entering attack state...");
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting attack state...");
    }

    public override void OnStateUpdate()
    {
        Attack();

        if (!(Physics.BoxCast(_turret.turretBarrel.position, _turret.turretBarrel.transform.localScale * 0.5f, _turret.turretBarrel.forward, out RaycastHit hit, _turret.turretBarrel.rotation, _turret.playerCheckDistance)))
        {
            Debug.Log("Player lost!");
            _turret.player = null;

            //Move to a new state
            //Move to the idle state
            _turret.ChangeState(new TurretIdleState(_turret));
            return;
        }
        else if (!(hit.transform.CompareTag("Player")))
        {
            Debug.Log("Non-player hit!");
            _turret.player = null;
            _turret.laser.SetPosition(1, hit.point);

            //Move to a new state
            //Move to the idle state
            _turret.ChangeState(new TurretIdleState(_turret));
        }

        _turret.laser.SetPosition(1, hit.point);
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.DeductHealth(damage * Time.deltaTime);
        }
    }
}
