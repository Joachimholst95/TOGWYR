using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject GameOverMenuUI;

    public void Awake()
    {
        GameManager.Load();
    }

    public void ToMainMenu()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
        GameManager.Save();
        Time.timeScale = 0f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        globals.score = 0;
    }

    public void QuitGame()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
        GameManager.Save();
        Application.Quit();
    }
    public Button PauseButton;
    public Button PauseButtonM;
    

    void Start()
    {
        Button pbtn = PauseButton.GetComponent<Button>();
        pbtn.onClick.AddListener(PauseGame);

        Button pbtnm = PauseButtonM.GetComponent<Button>();
        pbtnm.onClick.AddListener(ResumeGame);
    }

    void PauseGame()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
       pauseMenuUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
    }

    public void ResumeGame()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void RestartGame()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
        GameManager.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameIsPaused = false;
        globals.score = 0;
    }

    void GameOver()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        
    }
}