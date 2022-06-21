using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public CanvasGroup ToFadeOut;
    public CanvasGroup ToFadeTo;

    public void CallFade()
    {
        UIManager.Instance.StartFade(ToFadeOut, ToFadeTo);
    }
}

