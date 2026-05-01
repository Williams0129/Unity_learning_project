using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceObjectOnPlane2 : MonoBehaviour

{
    [SerializeField] GameObject placedPrefab2;
    GameObject SpawnedObject;//物件的參考
    ARRaycastManager raycaster;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycaster = GetComponent<ARRaycastManager>();
    }
    void OnPlaceObject(InputValue value)

    {

        Vector2 touchPosition = value.Get<Vector2>();
        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))//hits裡面只會存這一次的偵測結果
        {
            
            Pose hitPose = hits[0].pose;
            if (SpawnedObject == null)
            {
                
                SpawnedObject = Instantiate(placedPrefab2, hitPose.position, hitPose.rotation);
            }
            else
            {
               
                SpawnedObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            }

        }

    }

}