using UnityEngine;

[CreateAssetMenu(fileName ="Weapon Scriptable", menuName ="Weapons and Bullets/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public Bullet bulletPrefab;
    public int maxAmmo;
    public float ShotCD;
    public float ShotForce;
    public float ReloadCD;
    public int BulletsPerShoot;
}
