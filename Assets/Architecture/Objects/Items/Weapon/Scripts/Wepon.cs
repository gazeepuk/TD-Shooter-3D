using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    private PlayerController playerController;

    private Transform player; 

    //Weapon stats
    private int maxAmmo;
    private int currentAmmo;
    private float spread;
    private float reloadTime;
    private float timeBetweenBulletShot;
    private float timeBetweenShots;
    private int bulletsPerShot;

    //Bullet stats
    private float shootForce;
    [SerializeField]
    private GameObject bullet;


    private void Awake()
    {
        player = gameObject.GetComponentInParent<Transform>();
        playerController = new PlayerController();
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        playerController.Player.Shoot.started += ctx => Shooting();
    }
    private void OnDisable()
    {
        playerController.Player.Shoot.started -= ctx => Shooting();
    }

    private void Shooting()
    {
    }

    private void Reload()
    {

    }

}
