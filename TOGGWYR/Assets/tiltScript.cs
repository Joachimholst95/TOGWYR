using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tiltScript : MonoBehaviour
{
    public static TextMeshProUGUI tiltTMP;
    // Start is called before the first frame update
    void Start()
    {
        tiltTMP = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (globals.tilt)
        {
            tiltTMP.text = "Tilt active";
        }
        else
        {
            tiltTMP.text = "Tilt inactive";
        }
    }
}
