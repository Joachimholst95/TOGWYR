using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreScript : MonoBehaviour
{
    public static TextMeshProUGUI highscoreTMP;

    // Start is called before the first frame update
    void Start()
    {
        highscoreTMP = GetComponent<TextMeshProUGUI>();
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        SetScore();
    }

    public static void SetScore()
    {
        highscoreTMP.text = "Highscore: " + globals.highscore.ToString();
    }
}
