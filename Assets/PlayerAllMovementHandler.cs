using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAllMovementHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerRotation playerRotation;
    private void Awake()
    {
        playerMovement = gameObject.AddComponent<PlayerMovement>();
        playerRotation = gameObject.AddComponent<PlayerRotation>();
    }
    public void HandleAllMovements(Vector2 moveDirection, Vector2 lookRotation)
    {
        playerMovement.Move(moveDirection);
        playerRotation.RotatePlayer(lookRotation);
    }
}
