using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjectScript : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedGameObject;
        
    private ARRaycastManager _aRRaycastManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {        
        if(Input.touchCount > 0)
        {            
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(_aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            // we can write any logic here,
            // In this tutorial, this logic works like when the object is placed on the plane we are dragging into the planes tracked
            var hitPose = hits[0].pose;

            if (spawnedGameObject == null)
            {
                spawnedGameObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedGameObject.transform.position = hitPose.position;
            }
        }
    }
}
