using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    ShootInteractor interactor;
    Transform shootPoint;

    public RocketShootStrategy(ShootInteractor _interactor)
    {
        Debug.Log("Switched to rocket mode");
        this.interactor = _interactor;
        shootPoint = interactor.GetShootPoint();

        //Change gun colour
        interactor.gunRenderer.material.color = interactor.rocketColor;
    }
    public void Shoot()
    {
        PooledObjects pooledObj = interactor.rocketPool.GetPooledObjects();
        pooledObj.gameObject.SetActive(true);

        //Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bullet = pooledObj.GetComponent<Rigidbody>();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;

        bullet.velocity = shootPoint.forward * interactor.GetShootVelocity();

        //Destroy(bullet.gameObject, 5.0f);
        interactor.rocketPool.DestroyPooledObject(pooledObj, 5.0f);
    }
}
