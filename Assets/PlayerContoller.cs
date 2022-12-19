using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour, IMovable, IAttackable
{
    private Vector3 moveDirection;
    private CharacterController characterController;
    private float movementSpeed = 5f;

    private Weapon weapon;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        weapon = GetComponentInChildren<Weapon>();
    }

    private void FixedUpdate()
    {
        MoveInternal();
    }


    public void AttackPerformed()
    {
        weapon.AttackPerformed();
    }

    public void AttackCanceled()
    {
        weapon.AttackCanceled();
    }
    public void Move(Vector3 direction)
    {        
        moveDirection = direction;
    }

    public void MoveInternal()
    {
        characterController.Move(moveDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
