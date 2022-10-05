using UnityEngine;

public class CheckIfOffScreen
{
    public static bool IsVisible(GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        var point = target.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }
}
