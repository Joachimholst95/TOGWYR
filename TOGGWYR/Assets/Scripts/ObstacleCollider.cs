using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollider : MonoBehaviour
{
    public GameObject GameOverScreen;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == Constants.PlayerTag)
        {
            Debug.Log("Hit");
            
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
        }
    }
}
