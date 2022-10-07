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
        weapon = transform.GetChild(0).gameObject.AddComponent<Blaster>();
        weapon.UpdateWeapon(weaponScriptableObject, weaponBoxCollider);
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
