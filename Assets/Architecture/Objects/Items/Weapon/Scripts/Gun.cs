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


    private BoxCollider boxCollider;

    protected ObjectPool<Bullet> bulletPool;

    protected Transform bulletSpawnerPosition;

    #endregion

    #region Methods

    protected override void InitializeWeapon()
    {
        boxCollider = GetComponent<BoxCollider>();
        GunScriptableObject gunScriptableObject = weaponScriptableObject as GunScriptableObject;
        MaxAmmo = gunScriptableObject.maxAmmo;
        bulletPrefab = gunScriptableObject.bulletPrefab;
        ShotCD = gunScriptableObject.ShotCD;
        ShotForce = gunScriptableObject.ShotForce;
        ReloadCD = gunScriptableObject.ReloadCD;
        BulletsPerShot = gunScriptableObject.BulletsPerShot;
        bulletPrefab = gunScriptableObject.bulletPrefab;
        CurrentAmmo = MaxAmmo;
        bulletPool = BulletPool.Instance.pool;
        bulletSpawnerPosition = new GameObject("BulletSpawner").transform;
        bulletSpawnerPosition.SetParent(transform);
        bulletSpawnerPosition.position = GetBulletSpawnPosition();
        bulletSpawnerPosition.rotation = transform.rotation;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Attack()
    {
        Shooting();
    }
    private void Shooting()
    {
        if (!IsCanShoot())
            return;
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
