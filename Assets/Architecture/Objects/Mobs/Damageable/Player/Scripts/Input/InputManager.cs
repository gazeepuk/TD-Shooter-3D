using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController input;

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    private Vector2 inputDirection;
    public Vector2 MousePosition { get; private set; }
    private void Awake()
    {
        input = new PlayerController();
    }
    private void OnEnable()
    {
        input.Player.Movement.performed += ctx => inputDirection = ctx.ReadValue<Vector2>();
        input.Player.Aim.performed += ctx => Debug.Log(ctx.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        input.Player.Movement.performed -= ctx => inputDirection = ctx.ReadValue<Vector2>();
        input.Player.Aim.performed -= ctx => MousePosition = ctx.ReadValue<Vector2>();
    }

    public void HandleAllInputs()
    {
        HandleMovementInputs();
    }
    private void HandleMovementInputs()
    {
        HorizontalInput = inputDirection.x;
        VerticalInput = inputDirection.y;
    }
}
