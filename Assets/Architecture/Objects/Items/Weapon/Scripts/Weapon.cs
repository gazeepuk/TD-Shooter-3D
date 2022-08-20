using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Attributes
    private BoxCollider boxCollider;

    public int MaxAmmo { get; private set; }
    public float CurrentAmmo { get; private set; }
    public float ShootCD { get; private set; }
    public float ShootForce { get; private set; }

    private bool isCanShoot = true;
    private bool isCDPassed = true;

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
        ShootCD = weaponScriptableObject.ShootCD;
        ShootForce = weaponScriptableObject.ShootSpeed;
    }

    private void Awake()
    {
        InitializeWeapon();
        boxCollider = GetComponent<BoxCollider>();
        CurrentAmmo = MaxAmmo;
        bulletPool = new ObjectPool<Bullet>(bulletPrefab,30);
    }
    private void Update()
    {
        bulletSpawnerPosition = new Vector3(transform.position.x, transform.position.y, boxCollider.bounds.center.z + boxCollider.bounds.extents.z);

    }
    public void Shooting()
    {
        if (!IsCanShoot()) return;
        Shoot();
        StartCoroutine(StartCD());
    } 

    private bool IsCanShoot()
    {
        return isCanShoot && isCDPassed ? true : false;
    }

    IEnumerator StartCD()
    {
        isCDPassed = false;
        yield return new WaitForSeconds(ShootCD);
        isCDPassed = true;
    }
    protected virtual void Shoot()
    {
        Debug.Log($"Shoot");
    }
    #endregion
}
