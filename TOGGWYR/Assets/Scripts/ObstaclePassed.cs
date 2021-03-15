using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ObstaclePassed : MonoBehaviour
{
    private bool alreadyDone = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Constants.PlayerTag && !alreadyDone)
        {
            globals.score++;
            if (globals.score > globals.highscore)
            {
                globals.highscore = globals.score;
            }
        }
    }

    private void OnTriggerExit(Collider exit)
    {
        if (exit.gameObject.tag == Constants.PlayerTag)
        {
            alreadyDone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
