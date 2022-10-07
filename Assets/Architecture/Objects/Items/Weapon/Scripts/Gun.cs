using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon
{

    #region Attributes
    // In WeaponScriptableObject
    public int MaxAmmo { get; private set; }
    public float CurrentAmmo { get; private set; }
    public float ShotCD { get; private set; }
    public float ShotForce { get; private set; }
    public float ReloadCD { get; private set; }
    public int BulletsPerShot { get; private set; }

    private Bullet bulletPrefab;

    private bool isCanShoot = true;
    private bool isCDPassed = true;
    private bool isReloading = false;



    protected ObjectPool<Bullet> bulletPool;

    protected Transform bulletSpawnerPosition;

    private Transform bulletPoolContainer;

    #endregion

    #region Methods

    protected override void InitializeWeapon(WeaponScriptableObject weaponScriptableObject)
    {
        MaxAmmo = weaponScriptableObject.maxAmmo;
        bulletPrefab = weaponScriptableObject.bulletPrefab;
        ShotCD = weaponScriptableObject.ShotCD;
        ShotForce = weaponScriptableObject.ShotForce;
        ReloadCD = weaponScriptableObject.ReloadCD;
        BulletsPerShot = weaponScriptableObject.BulletsPerShoot;
    }

    private void Awake()
    {
        if (weaponScriptableObject == null)
            throw new System.Exception("WeaponScriptableObject is null");
        else
        {
            InitializeWeapon(weaponScriptableObject);
            CurrentAmmo = MaxAmmo;
        }
        if (bulletPoolContainer == null)
            throw new System.Exception("There is no container founded");
        bulletPool = BulletPool.pool;
        
    }

    public override void Attack()
    {
        Shooting();
    }
    private void Shooting()
    {
        if (!IsCanShoot()) return;
        Shoot();
        StartCoroutine(StartShootingCD());
    }

    private void Reload()
    {
        Debug.Log("Reloading");
        StartCoroutine(StartReloadCD());
    }

    private bool IsCanShoot()
    {
        if (!isCanShoot) return false;
        if (isReloading) return false;
        if (!isCDPassed) return false;
        if (CurrentAmmo < BulletsPerShot)
        {
            Reload();
            return false;
        }
        return true;
    }

    private IEnumerator StartShootingCD()
    {
        isCDPassed = false;
        yield return new WaitForSeconds(ShotCD);
        isCDPassed = true;
    }

    private IEnumerator StartReloadCD()
    {
        isReloading = true;
        yield return new WaitForSeconds(ReloadCD);
        CurrentAmmo = MaxAmmo;
        isReloading = false;
    }

    protected virtual void Shoot()
    {
        CurrentAmmo -= BulletsPerShot;
        //Child class Shoot
    }
    public Vector3 GetBulletSpawnPosition() => new Vector3(transform.position.x, transform.position.y,
        boxCollider.bounds.center.z + boxCollider.bounds.extents.z);

    #endregion
}
