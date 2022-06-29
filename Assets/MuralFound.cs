using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class MuralFound : MonoBehaviour
{

    public List<string> ImageNames;
    public List<GameObject> Panels; 
    public Dictionary<string, GameObject> Murals;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ImageNames.Count; i++)
        {
            Murals.Add(ImageNames[i], Panels[i]);
        }
    }

    public void ShowMuralUI(string name)
    {
        if (!Murals[name].activeSelf)
        {
            Murals[name].SetActive(true);
        }
    }
    
}
