using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class BgmScript : MonoBehaviour
{
    public bool DontDestroyEnabled = true;
    private void Awake()
    {
        int numBGM = FindObjectsOfType<BgmScript>().Length;
        if (numBGM > 1)
        {
            DontDestroyEnabled = false;
            Destroy(GameObject.Find("Audio"));
        }
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);
            this.name = "audio";
        }
    }
}
