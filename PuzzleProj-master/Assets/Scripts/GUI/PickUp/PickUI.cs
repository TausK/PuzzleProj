﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUI : MonoBehaviour
{
    public bool pickUI;

    private float scrW, scrH;
    // Use this for initialization
    void Start()
    {
        if (Screen.width / 16 != scrW || Screen.height / 9 != scrH)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;
        }
    }

    private void OnGUI()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;

        if (pickUI)
        {
            GUI.Box(new Rect(8 * scrW, 4.5f * scrH, 1 * scrW, 0.5f * scrH), "E Pick Up");
        }

    }


}
