using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    [SerializeField] private float maxAmmo, currentAmmo;
    [SerializeField] private float ShootCD;
    private bool isCanShoot = true;
    private bool isCDPassed = true;
    private void Awake()
    {
        playerController = new PlayerController();
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        playerController.Enable();
        playerController.Player.Shoot.performed += _ => Shoot();
    }

    private void OnDisable()
    {
        playerController.Disable();
        playerController.Player.Shoot.performed -= _ => Shoot();
    }

    private void Shoot()
    {
        if (!IsCanShoot()) return;
        //Take a bullet from a pool and Translate it
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
}
