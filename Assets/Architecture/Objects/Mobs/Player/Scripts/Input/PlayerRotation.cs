using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    #region Attributes
    [SerializeField] private float rotateSmooth = 1000f;
    #endregion
    #region Methods
    public void RotatePlayer(Vector2 lookDirection)
    {
        Debug.Log("Rotate");
        transform.LookAt(lookDirection, Vector3.up);
        /*
        Vector2 aim = input.Player.Aim.ReadValue<Vector2>();
        Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateSmooth * Time.fixedDeltaTime);
        }
        */
    }
    #endregion
}