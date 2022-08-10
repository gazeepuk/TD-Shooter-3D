using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMovable
{
    #region Attributes

    private PlayerController controller;

    [SerializeField] private float movementSpeed;
    #endregion
    #region Methods
    private void Awake()
    {
        controller = new PlayerController();
    }

    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 inputDirection = controller.Player.Movement.ReadValue<Vector2>();
        Move(inputDirection);
    }

    public void Move(Vector2 direction)
    {
        float speed = movementSpeed * Time.fixedDeltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * speed;
    }//IMovable
    #endregion
}
