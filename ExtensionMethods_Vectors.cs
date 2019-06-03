using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods_Vectors
{

    // Summary:
    //      Returns the euler angle that would be displayed by the object's transform in the inspector if the object was given a negative rotation.    
    public static Vector3 InspectorNegativeEulerAngles(this Transform transform)
    {
        Vector3 angles = transform.eulerAngles;
        if (angles.x > 180)
            angles.x = angles.x - 360;
        if (angles.y > 180)
            angles.y = angles.y - 360;
        if (angles.z > 180)
            angles.z = angles.z - 360;
        return angles;

    }
}
