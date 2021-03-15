using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 0f;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }
    protected GameManager()
    {
        GameState = GameState.Start;
        CanSwipe = false;
    }
 
    public GameState GameState { get; set; }
 
    public bool CanSwipe { get; set; }
    
    public void Die(bool b)
    {
        this.GameState = GameState.Dead;
    }
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        
        GameData data = new GameData();
        data.HScore = globals.highscore;
        data.MvmtF = globals.mvmtf;
        data.Volume = globals.volume;
        data.Tilt = globals.tilt;
        
        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();
            
            globals.highscore = data.HScore;
            globals.mvmtf = data.MvmtF;
            globals.volume = data.Volume;
            globals.tilt = data.Tilt;
            Debug.Log("Loaded");
        }
    }
}
[Serializable]
class GameData
{
    public float HScore;
    public float MvmtF;
    public float Volume;
    public bool Tilt;
}