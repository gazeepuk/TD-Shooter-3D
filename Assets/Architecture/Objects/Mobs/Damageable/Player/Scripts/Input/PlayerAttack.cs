using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Weapon weapon;

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    private void OnEnable()
    {
        InputManager.Instance.OnShootPressedEvent += Attack;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnShootPressedEvent -= Attack;
    }
    public void Attack()
    {
        weapon.Attack();
    }

    public void SetWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
}
