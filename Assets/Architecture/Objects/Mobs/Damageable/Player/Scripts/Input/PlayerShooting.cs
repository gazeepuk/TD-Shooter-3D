using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Weapon weapon;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = new PlayerController();
        weapon = GetComponentInChildren<Weapon>();
    }

    private void OnEnable()
    {
        playerController.Enable();
        playerController.Player.Shoot.performed += _ => weapon?.Shooting();
    }

    private void OnDisable()
    {
        playerController.Disable();
        playerController.Player.Shoot.performed -= _ => weapon?.Shooting();
    }
}
