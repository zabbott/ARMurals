using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterestPoint : MonoBehaviour
{
    public string Description;
    public Button MyButton;

    private void Update()
    {
        transform.LookAt(ContentManager.Instance.LookAtAnchor);
    }

    public void TappedInterestPoint()
    {
        UIManager.Instance.DescriptionText.text = Description;
        UIManager.Instance.PopUpImage.gameObject.SetActive(true);
        UIManager.Instance.PopUpImage.alpha = 1;
        UIManager.Instance.PopUpImage.blocksRaycasts = true;
        UIManager.Instance.PopUpImage.interactable = true;

    }
}
