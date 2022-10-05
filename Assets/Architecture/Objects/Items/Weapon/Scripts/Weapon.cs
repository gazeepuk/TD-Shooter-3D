using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Weapon : MonoBehaviour
{

    #region Attributes
    private BoxCollider boxCollider;


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


    [SerializeField]
    private WeaponScriptableObject weaponScriptableObject;

    protected ObjectPool<Bullet> bulletPool;

    protected Transform bulletSpawnerPosition;
    private Transform bulletPoolContainer;
    #endregion

    #region Methods
    public Weapon(WeaponScriptableObject weaponScriptableObject)
    {
        this.weaponScriptableObject = weaponScriptableObject;
        InitializeWeapon(weaponScriptableObject);
    }

    private void InitializeWeapon(WeaponScriptableObject weaponScriptableObject)
    {
        MaxAmmo = weaponScriptableObject.maxAmmo;
        bulletPrefab = weaponScriptableObject.bulletPrefab;
        ShotCD = weaponScriptableObject.ShotCD;
        ShotForce = weaponScriptableObject.ShotForce;
        ReloadCD = weaponScriptableObject.ReloadCD;
        BulletsPerShot = weaponScriptableObject.BulletsPerShoot;
        boxCollider = GetComponent<BoxCollider>();
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
        bulletPool = new ObjectPool<Bullet>(bulletPrefab,30,new GameObject("BulletPool").transform);
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
    public Vector3 GetBulletSpawnPosition() => new Vector3(transform.position.x, transform.position.y,
        boxCollider.bounds.center.z + boxCollider.bounds.extents.z);

    #endregion
}
