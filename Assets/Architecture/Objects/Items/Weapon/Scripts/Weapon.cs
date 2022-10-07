using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    #region Attributes
    protected BoxCollider boxCollider;
    protected WeaponScriptableObject weaponScriptableObject;
    #endregion

    #region Methods
    public Weapon(WeaponScriptableObject weaponScriptableObject, BoxCollider boxCollider)
    {
        this.weaponScriptableObject = weaponScriptableObject;
        InitializeWeapon(weaponScriptableObject);
    }

    protected abstract void InitializeWeapon(WeaponScriptableObject weaponScriptableObject);
    public abstract void Attack();
    #endregion
}
