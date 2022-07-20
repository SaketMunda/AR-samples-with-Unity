using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingScript : MonoBehaviour
{
    private ARTrackedImageManager aRTrackedImageManager;

    private void Awake()
    {
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    // Using OnEnable() and OnDisable to bind and unbind OnImageChage event 
    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChange;
    }
    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChange;
    }

    private void OnImageChange(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {            
            // Do something
        }
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            // Do something
        }
        foreach (ARTrackedImage trackedImage in args.removed)
        {
            // Do something
        }
    }
}
