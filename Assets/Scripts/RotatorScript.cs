using UnityEngine;

public class RotatorScript : MonoBehaviour
{
 protected void LookAt(Vector3 Target) //protected = only this script and scripts that inherit from it can use this method
    {
        float lookAngle = AngleBetweenTwoPoints(transform.position,Target) + 90;

        transform.eulerAngles = new Vector3(0, 0, lookAngle); // in 2D, objects only rotate around the Z axis
    }



    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;  // Atan2 turns a direction into an angle (in radians), Rad2Deg converts it to degrees
    }

}
