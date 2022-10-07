using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gun Scriptable", menuName = "Weapons and Bullets/Weapons/Gun")]
public class GunScriptableObject : WeaponScriptableObject
{
    public int maxAmmo;
    public Bullet bulletPrefab;
    public float ShotCD;
    public float ShotForce;
    public float ReloadCD;
    public int BulletsPerShot;

}
