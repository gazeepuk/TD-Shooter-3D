using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    #region Attributes
    protected BoxCollider boxCollider;
    public WeaponScriptableObject weaponScriptableObject;
    #endregion

    #region Methods

    protected virtual void InitializeWeapon(WeaponScriptableObject weaponScriptableObject) { }
    public virtual void Attack() { }
    public void UpdateWeapon(WeaponScriptableObject weaponScriptableObject, BoxCollider boxCollider)
    {
        this.weaponScriptableObject = weaponScriptableObject;
        InitializeWeapon(weaponScriptableObject);
    }
    #endregion
}
