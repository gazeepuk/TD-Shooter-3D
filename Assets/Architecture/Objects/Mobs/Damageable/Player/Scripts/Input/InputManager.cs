using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerController input;

    public static InputManager Instance;

    public event Action OnShootPressedEvent;
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    private Vector2 inputDirection;
    public Vector2 MousePosition { get; private set; }
    private void Awake()
    {
        input = new PlayerController();

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += ctx => inputDirection = ctx.ReadValue<Vector2>();
        input.Player.Aim.performed += HandleMousePositionInput;
        input.Player.Attack.performed += _ => OnShootPressed();
        input.Player.Attack.performed += _ => Debug.Log("Performed");
      }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= ctx => inputDirection = ctx.ReadValue<Vector2>();
        input.Player.Aim.performed -= HandleMousePositionInput;
        input.Player.Attack.performed -= _ => OnShootPressed();
    }

    public void OnShootPressed()
    {
        OnShootPressedEvent?.Invoke();
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
    private void HandleMousePositionInput(InputAction.CallbackContext ctx)
    {
        MousePosition = ctx.ReadValue<Vector2>();
    }
}
