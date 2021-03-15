using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globals : MonoBehaviour
{
    public static float score = 0.0f;

    public static float highscore;

    public static float volume;

    public static float mvmtf = 0.0f;

    public static bool tilt;

    public void awake()
    {
        
        Debug.Log("gamemanager: " + gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
