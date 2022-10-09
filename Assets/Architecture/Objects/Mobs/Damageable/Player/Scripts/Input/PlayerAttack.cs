using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Weapon weapon;

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    public void Attack()
    {
        if(InputManager.Instance.IsLeftMouseButtonPressed)
            weapon.Attack();
    }

    public void SetWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
}
