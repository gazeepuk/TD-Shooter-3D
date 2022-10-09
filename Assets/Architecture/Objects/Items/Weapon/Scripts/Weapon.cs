using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    #region Attributes
    [SerializeField]
    protected WeaponScriptableObject weaponScriptableObject;

    protected BoxCollider weaponBoxCollider;

    #endregion

    #region Methods
    protected virtual void Awake()
    {
        InitializeWeapon();
    }
    protected abstract void InitializeWeapon();
    public abstract void Attack();
    public void UpdateWeapon(WeaponScriptableObject weaponScriptableObject ,Weapon newWeapon)
    {
        InitializeWeapon();
    }
    #endregion
}
