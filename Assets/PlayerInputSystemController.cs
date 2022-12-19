using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystemController : MonoBehaviour
{
    private IMovable contollable;
    private IAttackable attackable;

    private GameInput input;

    private void Awake()
    {
        contollable = GetComponent<IMovable>();
        attackable = GetComponent<IAttackable>();
        input = new GameInput();
        input.Enable();
    }

    private void OnEnable()
    {
        input.Player.Attack.performed += OnAttackPerformed;
        input.Player.Attack.canceled += OnAttackCanceled;
    }

    private void Update()
    {
        ReadMovement();
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        attackable.AttackPerformed();
    }

    private void OnAttackCanceled(InputAction.CallbackContext context)
    {
        attackable.AttackCanceled();
    }

    private void ReadMovement()
    {
        var inputDirection = input.Player.Movement.ReadValue<Vector2>();
        contollable.Move(new Vector3(inputDirection.x, 0, inputDirection.y));
    }
}
