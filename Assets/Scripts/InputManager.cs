using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public bool touchIsOnUI;
    public Vector2 CachedDragPosition;
    public float RotateSpeed;
    public bool SetInterestPointInteractible;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.touchCount > 0 && ContentManager.Instance.currentObject != null)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if (SetInterestPointInteractible == false)
                {
                    ContentManager.Instance.currentObject.GetComponent<ViewerObject>().ToggleInterestPoints(false);
                    SetInterestPointInteractible = true;
                }
                ContentManager.Instance.currentObject.transform.Rotate(touch.deltaPosition.y * RotateSpeed, -touch.deltaPosition.x * RotateSpeed, 0, Space.World);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                ContentManager.Instance.currentObject.GetComponent<ViewerObject>().ToggleInterestPoints(true);
                SetInterestPointInteractible = false;

            }
        }
    }
}
