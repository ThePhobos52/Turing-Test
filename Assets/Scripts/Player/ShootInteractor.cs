using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{

    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletColor;
    public Color rocketColor;

    [Header("Shoot")]
    //[SerializeField] private Rigidbody bulletPrefab;
    public ObjectPool bulletPool;
    public ObjectPool rocketPool;
    
    [SerializeField] private float shootVelocity;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private PlayerMoveBehaviour moveBehaviour;

    private float finalShootVelocity;
    private IShootStrategy currentShootStrategy;

    public override void Interact()
    {
        if(currentShootStrategy == null)
        {
            currentShootStrategy = new BulletShootStrategy(this);
        }
        if (input.weapon1Pressed)
        {
            currentShootStrategy = new BulletShootStrategy(this);
        }
        if (input.weapon2Pressed)
        {
            currentShootStrategy = new RocketShootStrategy(this);
        }

        //Shoot Strategy
        if (input.primaryShootPressed && currentShootStrategy != null)
        {
            currentShootStrategy.Shoot();
        }
    }

    /*void Shoot()
    {
        PooledObjects pooledObj = objPool.GetPooledObjects();
        pooledObj.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * finalShootVelocity;

        //Destroy(bullet.gameObject, 5.0f);
        objPool.DestroyPooledObject(pooledObj, 5.0f);
    }*/

    public Transform GetShootPoint()
    {
        return shootPoint;
    }

    public float GetShootVelocity()
    {
        finalShootVelocity = moveBehaviour.GetForwardSpeed() + shootVelocity;
        return finalShootVelocity;
    }
}
