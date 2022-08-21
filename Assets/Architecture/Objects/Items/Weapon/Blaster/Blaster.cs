using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    protected override void Shoot()
    {
        var bullet = bulletPool.GetFreeElement();
        bullet.transform.position = GetBulletSpawnPosition();
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * ShootForce, ForceMode.Impulse);
    }

}
