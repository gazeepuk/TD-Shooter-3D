using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    public Blaster(WeaponScriptableObject weaponScriptableObject) : base(weaponScriptableObject) { }
    protected override void Shoot()
    {
        base.Shoot();
        var bullet = bulletPool.GetFreeElement();
        //var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawnerPosition.position;
        bullet.transform.rotation = bulletSpawnerPosition.rotation;
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * ShotForce;

    }

}
