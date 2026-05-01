using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceObjectOnPlane : MonoBehaviour

{
    [SerializeField] GameObject placedPrefab;
    GameObject spawnedObject;//物件的參考
    void OnPlaceObject(InputValue value)

    {

        Vector2 touchPosition = value.Get<Vector2>();// get the screen touch position
                                                     // input value是一個通用容器，之前在action設定的vector2才是我們的目標資訊，所以要取的型態是vector2，vector2是一個struct

        // raycast from the touch position into the 3D scene looking for a plane
        // if the raycast hit a plane then
        ARRaycastManager raycaster = GetComponent<ARRaycastManager>();//從目前這個腳本掛載的 GameObject 上，找到 ARRaycastManager 元件，使raycaster成為其參考。 

        List<ARRaycastHit> hits = new List<ARRaycastHit>();//建立一個空的 hits 清單，準備拿來裝 Raycast 命中的結果。

        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))//Raycast如果打到東西會回傳true，否則傳False
                                                                                     //第一個參數是螢幕點擊座標，第二個是拿來裝結果的清單
                                                                                     //第三個參數是射線要偵測的型別
        {
            // get the hit point (pose) on the plane
            Pose hitPose = hits[0].pose;//Pose是struct，包含position跟rotation

            // if this is the first time placing an object,
            if (spawnedObject == null)
            {
                // instantiate the prefab at the hit position and rotation
                spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                // change the position of the previously instantiated object
                spawnedObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            }

        }

    }

}