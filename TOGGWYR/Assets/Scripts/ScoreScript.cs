using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    
    public static TextMeshProUGUI scoreTMP;

    // Start is called before the first frame update
    void Start()
    {
        scoreTMP = GetComponent<TextMeshProUGUI>();
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        SetScore();
    }

    public static void SetScore()
    {
        scoreTMP.text = "Score: " + globals.score.ToString();
    }
}
