using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Slider vSlider;
    public Slider mvmtSlider;
    public Toggle tiltToggle;
    
    public void Awake()
    {
        GameManager.Load();
        vSlider.value = globals.volume;
        mvmtSlider.value = globals.mvmtf;
        tiltToggle.isOn = globals.tilt;
    }

    public void Update()
    {
        tiltToggle.isOn = globals.tilt;
    }

    public void ButtonPressed()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
        GameManager.Save();
    }
    public void PlayGame()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
        Time.timeScale = 1f;
        SceneManager.LoadScene("TOGWYR");
    }

    public void QuitGame()
    {
        FindObjectOfType<SoundManager>().PlaySound("Button");
        GameManager.Save();
        Application.Quit();
    }

    public void Volume()
    {
        AudioListener.volume = vSlider.value;
        globals.volume = vSlider.value;
        GameManager.Save();
    }

    public void MovementForce()
    {
        globals.mvmtf = mvmtSlider.value;
    }

    public void Tilt()
    {
        globals.tilt = !globals.tilt;
        GameManager.Save();
    }
}