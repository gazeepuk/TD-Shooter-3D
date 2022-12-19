using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Attributes
    [SerializeField] 
    private float movementSpeed = 5f;
    [SerializeField]
    private CharacterController characterController;
    #endregion
    #region Methods
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        characterController.Move(moveDirection * movementSpeed * Time.fixedDeltaTime);
    }
    #endregion
}
