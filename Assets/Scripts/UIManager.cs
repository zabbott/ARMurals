using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    public float fadeSpeed;

    public CanvasGroup PopUpImage;
    public TMP_Text DescriptionText;
    public HeaderButton[] togglablebuttons;
    public GameObject TutorialPanel;
    public VideoPlayer TutorialVideo;
    public GameObject TutorialPanelTwo;
    public VideoPlayer TutorialVideoTwo;

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
        StartTutorial();//this will get replaced when the loading screen is done//
    }

    public void CloseMessagePopUp()
    {
        PopUpImage.alpha = 0;
        PopUpImage.blocksRaycasts = false;
        PopUpImage.interactable = false;

    }
    public void ResetIteam()
    {
        ContentManager.Instance.currentObject.GetComponent<ViewerObject>().ResetRotation();
    }

    public void StartFade(CanvasGroup ToFadeOut, CanvasGroup ToFadeTo)
    {
        StartCoroutine(Fade(ToFadeOut, ToFadeTo));
    }
    public IEnumerator Fade(CanvasGroup ToFadeout, CanvasGroup ToFadeTo)
    {

        ToFadeTo.interactable = false;
        ToFadeTo.blocksRaycasts = false;
        ToFadeout.interactable = false;
        ToFadeout.blocksRaycasts = false;
        while (ToFadeTo.alpha < 1 || ToFadeout.alpha > 0)
        {
            ToFadeTo.alpha += fadeSpeed;
            ToFadeout.alpha -= fadeSpeed;
            yield return null;
        }
        ToFadeTo.interactable = true;
        ToFadeTo.blocksRaycasts = true;

    }
    public void ToggleHeaderButton(HeaderButton ToTurnOn)
    {
        foreach (var button in togglablebuttons)
        {
            if(button == ToTurnOn)
            {
                button.SetClickedImage();
            }
            else
            {
                button.SetOriginalImage();
            }
        }
    }
    public void StartTutorial()
    {
        TutorialPanel.SetActive(true);
        TutorialVideo.Play();
        TutorialPanelTwo.SetActive(false);
        TutorialVideoTwo.Stop();

    }
    public void StartSecondTutorial()
    {
        TutorialVideo.Stop();
        TutorialPanel.SetActive(false);
        TutorialPanelTwo.SetActive(true);
        TutorialVideoTwo.Play();

    }
    public void StopTutorial()
    {
        TutorialPanel.SetActive(false);
        TutorialPanelTwo.SetActive(false);
        TutorialVideo.Stop();
        TutorialVideoTwo.Stop();
    }
}