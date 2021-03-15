using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("trigger");
        if (collision.gameObject.tag.Equals((Constants.ObstacleTag)))
        {
            //sDebug.Log("player did collide");
            FindObjectOfType<SoundManager>().PlaySound("Hit");
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
