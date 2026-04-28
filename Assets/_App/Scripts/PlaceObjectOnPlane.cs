using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.InputSystem;

using UnityEngine.XR.ARFoundation;

using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlane : MonoBehaviour

{

    void OnPlaceObject(InputValue value)

    {

        Vector2 touchPosition = value.Get<Vector2>();// get the screen touch position
                                                     // input value是一個通用容器，之前在action設定的vector2才是我們的目標資訊，所以要娶的型態是vector2

        // raycast from the touch position into the 3D scene looking for a plane

        // if the raycast hit a plane then
        ARRaycastManager raycaster = GetComponent<ARRaycastManager>();

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))

        {

            //

        }

        //      get the hit point (pose) on the plane

        //      if this is the first time placing an object,

        //          instantiate the prefab at the hit position                     and rotation

        //      else

        //          change the position of the previously                     instantiated object

    }

}