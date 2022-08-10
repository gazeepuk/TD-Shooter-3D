using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    #region Attributes
    private PlayerController input;
    [SerializeField] private float movementSpeed;
    #endregion
    #region Methods
    private void Awake()
    {
        input = new PlayerController();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 vectorInput = input.Player.Movement.ReadValue<Vector2>();
        Move(vectorInput);

    }
    public void Move(Vector2 direction)
    {
        float speed = movementSpeed * Time.fixedDeltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * speed;
    }
    #endregion
}
