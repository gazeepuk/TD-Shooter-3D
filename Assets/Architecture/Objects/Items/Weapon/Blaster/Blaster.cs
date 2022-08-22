using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    protected override void Shoot()
    {
        base.Shoot();
        //var bullet = bulletPool.GetFreeElement();
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawnerPosition.position;
        bullet.transform.rotation = bulletSpawnerPosition.rotation;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * ShotForce, ForceMode.Impulse);

    }

}
