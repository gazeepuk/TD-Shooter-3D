using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    #region Attributes
    private PlayerController input;
    [SerializeField] private float rotateSmooth = 1000f;
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
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Vector2 aim = input.Player.Aim.ReadValue<Vector2>();
        Vector3 playerDirection = new Vector3(aim.x, 0, aim.y);
        if (playerDirection.sqrMagnitude > 0.1f)
        {
            Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateSmooth * Time.fixedDeltaTime);
        }
    }
    #endregion
}