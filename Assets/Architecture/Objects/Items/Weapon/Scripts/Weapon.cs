using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Attributes
    protected virtual float maxAmmo { get { return 10; } }
    protected virtual float currentAmmo { get; private set; }

    protected virtual float ShootCD { get { return 0.5f; } }

    private bool isCanShoot = true;
    private bool isCDPassed = true;

    #endregion
    #region Methods
    private void Awake()
    {
        currentAmmo = maxAmmo;
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
        Debug.Log("Shoot");
        //Take a bullet from a pool and Translate it
    }
    #endregion
}
