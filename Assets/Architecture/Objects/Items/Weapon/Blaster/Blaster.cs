using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Gun
{
    public Blaster(WeaponScriptableObject weaponScriptableObject, BoxCollider boxCollider) : base(weaponScriptableObject, boxCollider) { }
    protected override void Shoot()
    {
        base.Shoot();
        var bullet = bulletPool.GetFreeElement();
        bullet.transform.position = bulletSpawnerPosition.position;
        bullet.transform.rotation = bulletSpawnerPosition.rotation;
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * ShotForce;
    }
}
