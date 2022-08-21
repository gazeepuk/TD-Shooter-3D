using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    #region Attributes
    private BoxCollider boxCollider;

    public int MaxAmmo { get; private set; }
    public float CurrentAmmo { get; private set; }
    public float ShotCD { get; private set; }
    public float ShotForce { get; private set; }
    public float ReloadCD { get; private set; }
    public int BulletsPerShot { get; private set; }
    private bool isCanShoot = true;
    private bool isCDPassed = true;
    private bool isReloading = false;

    private Bullet bulletPrefab;

    [SerializeField]
    private WeaponScriptableObject weaponScriptableObject;

    protected ObjectPool<Bullet> bulletPool;

    protected Vector3 bulletSpawnerPosition;

    #endregion

    #region Methods
    private void InitializeWeapon()
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
        InitializeWeapon();
        boxCollider = GetComponent<BoxCollider>();
        CurrentAmmo = MaxAmmo;
        bulletPool = new ObjectPool<Bullet>(bulletPrefab,30);
    }

    public void Shooting()
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
        if(!isCanShoot) return false;
        if(isReloading) return false;
        if(!isCDPassed) return false;
        if(CurrentAmmo < BulletsPerShot)
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
    }
    protected Vector3 GetBulletSpawnPosition() => new Vector3(transform.position.x, transform.position.y, boxCollider.bounds.center.z + boxCollider.bounds.extents.z);
    #endregion
}
