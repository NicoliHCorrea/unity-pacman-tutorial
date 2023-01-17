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

    void Start()
    {

    }

    public void GameStart()
    {   
        DateTime localDate = DateTime.Now;
        string message = localDate.ToString("dd/MM/yyyy HH:mm:ss");
        allText.Add(message);
        message = "Música selecionada: "+ scriptable.getMusic();
        allText.Add(message);
        
    }

    public void endGame(){
        WriteToLogFile();
    }

    public void WriteToLogFile (){
        using (StreamWriter writer = new StreamWriter(@"C:\Users\nicol\Documents\GitHub\unity-pacman-tutorial\LogFile.txt")){
            foreach (string item in allText)
            {
                writer.WriteLine(item);
            }
        } 
    }

}
