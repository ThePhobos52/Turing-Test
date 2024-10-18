using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private TurretState currentState;
    public Transform turretBarrel;
    public float playerCheckDistance;

    // Laser visual
    [SerializeField] public LineRenderer laser;
    [SerializeField] private Transform startPoint;
    public Vector3 endPoint;

    [HideInInspector] public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        laser.SetPosition(0, startPoint.position);
        endPoint = turretBarrel.position + (turretBarrel.forward * playerCheckDistance);
        laser.SetPosition(1, endPoint);
        currentState = new TurretIdleState(this);
        currentState.OnStateEnter();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeState(TurretState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(turretBarrel.position, turretBarrel.forward * playerCheckDistance);
    }
}
