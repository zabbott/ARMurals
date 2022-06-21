using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    public static ContentManager Instance;
    public GameObject[] AllofOurModels;
    public GameObject currentObject;
    public Transform LookAtAnchor;

    public void Awake()
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
    public void ToggleModels(int whichModelShouldBeOn)
    {
        for (int i = 0; i < AllofOurModels.Length; i++)
        {
            if (i == whichModelShouldBeOn)

            {
                AllofOurModels[i].SetActive(true);
                currentObject = AllofOurModels[i];

            }
            else
            {
                AllofOurModels[i].SetActive(false);
            }
        }
    }
}