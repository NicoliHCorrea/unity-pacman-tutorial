using UnityEngine;

[CreateAssetMenu(fileName = "MusicName", menuName = "")]
public class MusicName : ScriptableObject
{
    public string myMusic = "Normal";

    public void changeMusic(string name){
        myMusic = name;
    }

    public string getMusic (){
        return myMusic;
    }
}

