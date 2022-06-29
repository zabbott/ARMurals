using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARImageRecognition : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public bool canScan;
    public List<string> foundNames;
    public float Timer;
    public MuralFound MuralFoundLogic;
    private void OnEnable()
    {
        StartCoroutine(KeepTime());
        trackedImageManager.trackedImagesChanged += ImageChanged;
        
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs args)
    {

        foreach (var item in args.added)
        {
            if (canScan == true)
            {
                if (item.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                {
                    foundNames.Add(item.referenceImage.name);
                    MuralFoundLogic.ShowMuralUI(item.referenceImage.name);
                }
            }
        }
        foreach (var item in args.updated)
        {
            if (canScan == true)
            {
                if (item.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                {
                    foundNames.Add(item.referenceImage.name);
                    MuralFoundLogic.ShowMuralUI(item.referenceImage.name);

                }
                else if (item.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
                {
                    if (foundNames.Contains(item.referenceImage.name))
                    {
                        foundNames.Remove(item.referenceImage.name);
                    }
                }
            }


        }
    }
    public void GetNewTime()
    {
        Timer = Time.time;
    }
    public IEnumerator KeepTime()
    {
        GetNewTime();
        while (true)
        {
            var timePassed = Time.time - Timer;
            if (timePassed > 2f)
            {
                GetNewTime();
            
                if (foundNames.Count > 1)
                {

                    foundNames.Clear();
                }
            }
            yield return null;
        }
    }
}
