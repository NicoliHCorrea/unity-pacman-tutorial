using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;
using System.IO;

public class LogFile : MonoBehaviour
{   
    [SerializeField] public MusicName scriptable; 
    public List<string> allText = new List<string>();
    public List<string> heartBeats = new List<string>();
    public static LogFile instance;
    public DateTime LocalDate;

    private string path_note = @"C:\Users\nicol\Documents\GitHub\unity-pacman-tutorial\LogFile.txt";
    private string path_pc = @"D:\unity-pacman-tutorial2\LogFile.txt";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void GameStart()
    {
        DateTime localDate = DateTime.Now;
        string message = localDate.ToString("dd/MM/yyyy HH:mm:ss");
        allText.Add(message);
        message = "Música selecionada: " + scriptable.getMusic();
        allText.Add(message);
        
    }

    public void endGame(){
        DateTime newTime = DateTime.Now;
        allText.Add("Duração da partida: " + newTime.Subtract(LocalDate).Seconds + "s");
        WriteToLogFile();
    }

    public void WriteToLogFile (){
        using (StreamWriter writer = new StreamWriter(path_note)){
            foreach (string item in allText)
            {
                writer.WriteLine(item);
            }
            foreach(string item in heartBeats)
            {
                writer.WriteLine(item);
            }
        } 
    }

}
