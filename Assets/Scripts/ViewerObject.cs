using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewerObject : MonoBehaviour
{
    public InterestPoint[] InterestPoint;
    public Quaternion StartRotation;
    private void Start()
    {
        StartRotation = transform.rotation;
    }

    public void ToggleInterestPoints(bool enabledOrDisable)
    {

        foreach (var button in InterestPoint)
        {
            button.MyButton.interactable = enabledOrDisable;
            button.MyButton.GetComponent<Image>().raycastTarget = enabledOrDisable;
        }
    }

    public void ResetRotation()
    {
        transform.rotation = StartRotation;
    }
}
