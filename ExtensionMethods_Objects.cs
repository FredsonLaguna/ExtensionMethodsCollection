using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public static class ExtensionMethods_Objects
{

    // Summary:
    //      Extension method that will return an object of type T that is the closest to the gameobject calling this method
    //
    // Parameters:
    //      arrayOfT:
    //          An array of type T that will be used to select the closest
    //      filter:
    //          An optional argument, a predicate delegate that can be used as an additional filter to disregard objects that do not meet specific criteria
    public static T GetClosestObject<T>(this Transform transform, T[] arrayOfT, Predicate<T> filter = null) where T : MonoBehaviour
    {
        float shortestDist = Mathf.Infinity;
        float distanceFromNewObj;
        int shortestPosIndex = 0;

        for (int i = 0; i < arrayOfT.Length; i++)
        {
            distanceFromNewObj = Vector3.Distance(transform.position, arrayOfT[i].transform.position);
            bool compareDistance = true;

            if (filter != null)                                
                compareDistance = filter.Invoke(arrayOfT[i]);

            if (compareDistance && (distanceFromNewObj < shortestDist))
            {
                shortestDist = distanceFromNewObj;
                shortestPosIndex = i;
            }

        }

        return arrayOfT[shortestPosIndex];
    }

    // Summary:
    //      Overloaded method that compares all objects of type T in the scene to the position of the gameobject calling this method.
    public static T GetClosestObject<T>(this Transform transform, Predicate<T> filter = null) where T : MonoBehaviour
    {
        T[] arrayOfT = GameObject.FindObjectsOfType<T>();
        return GetClosestObject(transform, arrayOfT, filter);
    }


    public static void ChangeLayersRecursively(this Transform trans, string layerName)
    {
        trans.gameObject.layer = LayerMask.NameToLayer(layerName);
        foreach (Transform child in trans)
        {
            child.gameObject.layer = LayerMask.NameToLayer(layerName);
            ChangeLayersRecursively(child, layerName);
        }
    }

    public static void SetChildrenActive(this GameObject go, bool isActive)
    {
        foreach (Transform item in go.transform)
        {
            item.gameObject.SetActive(isActive);
        }
    }
}
