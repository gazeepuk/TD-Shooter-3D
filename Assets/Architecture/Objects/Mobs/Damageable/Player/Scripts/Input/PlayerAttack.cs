using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Weapon weapon;
    private WeaponScriptableObject weaponScriptableObject;
    private BoxCollider weaponBoxCollider;

    private void Awake()
    {
        weaponBoxCollider = GetComponentInChildren<BoxCollider>();
        weaponScriptableObject = Resources.Load<WeaponScriptableObject>("WeaponScriptableObjects/BlasterScriptable");
        Weapon weapon = new Blaster(weaponScriptableObject, weaponBoxCollider);
    }

    private void OnEnable()
    {
        InputManager.OnShootPressedEvent += Attack;
    }

    private void OnDisable()
    {
        InputManager.OnShootPressedEvent -= Attack;
    }
    public void Attack()
    {
        weapon.Attack();
        Debug.Log("Player Attack");
    }

    public void SetWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
}
