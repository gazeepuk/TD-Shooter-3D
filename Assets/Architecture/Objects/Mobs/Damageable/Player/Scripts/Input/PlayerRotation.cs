using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    #region Attributes
    [SerializeField] 
    private float rotateSmooth = 1000f;
    #endregion
    #region Methods
    public void RotatePlayer(Vector2 lookDirection)
    {
        Ray ray = Camera.main.ScreenPointToRay(lookDirection);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if(plane.Raycast(ray, out var rayDistance))
        {
            Vector3 lookPoint = ray.GetPoint(rayDistance);
            lookPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
            transform.LookAt(lookPoint);
        }
        /*
        Vector2 aim = input.Player.Aim.ReadValue<Vector2>();
        Vector3 playerDirection = new Vector3(aim.x, 0, aim.y);
        if (playerDirection.sqrMagnitude > 0.1f)
        {
            Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateSmooth * Time.fixedDeltaTime);
        }
        */
    }
    #endregion
}