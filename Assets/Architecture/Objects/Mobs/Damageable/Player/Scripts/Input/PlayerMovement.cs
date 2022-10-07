using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    #region Attributes
    [SerializeField] private float movementSpeed = 5f;
    #endregion
    #region Methods
    public void Move(Vector2 direction)
    {
        float speed = movementSpeed * Time.fixedDeltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * speed;
    }
    #endregion
}
