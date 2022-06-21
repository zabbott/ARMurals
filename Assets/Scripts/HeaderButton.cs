using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class HeaderButton : MonoBehaviour
{
    public Sprite Filled;
    public Sprite Hollow;
    public Button button;
    public void SetClickedImage()
    {
        button.image.sprite = Filled;
    }
    public void SetOriginalImage()
    {
        button.image.sprite = Hollow;
    }
}
