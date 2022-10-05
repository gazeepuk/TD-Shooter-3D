using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerAllMovementHandler playerMovementHandler;
    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        var moveDirection = new Vector3(inputManager.HorizontalInput, inputManager.VerticalInput);
        playerMovementHandler.HandleAllMovements(moveDirection, inputManager.MousePosition);
    }

}
