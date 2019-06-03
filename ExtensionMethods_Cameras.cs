using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods_Cameras
{

    // Summary:
    //      Gets the camera frustum height based on a given distance
    //
    // Parameters:
    //      distance: 
    //          the distance from the camera
    public static float GetFrustumHeight(this Camera cam, float distance)
    {
        return 2 * distance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    public static float GetFrustumWidth(this Camera cam, float distance)
    {
        return GetFrustumHeight(cam, distance) * cam.aspect;
    }
}
