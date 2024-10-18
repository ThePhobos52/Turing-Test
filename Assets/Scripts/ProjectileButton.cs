using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileButton : MonoBehaviour
{
    [SerializeField] int[] affectedLayers;
    public UnityEvent ObjectHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (affectedLayers.Contains(collision.gameObject.layer))
        {
            ObjectHit?.Invoke();
        }
    }
}
