using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{   
    [SerializeField] private ToggleGroup game;
    [SerializeField] private ToggleGroup music;
    [SerializeField] private MusicName scriptable;
    // Start is called before the first frame update
    public void Submit()
    {
        Toggle curMusic = music.ActiveToggles().FirstOrDefault();
        Toggle curGame = game.ActiveToggles().FirstOrDefault();
        scriptable.changeMusic(curMusic.GetComponentInChildren<TextMeshProUGUI>().text);
        SceneManager.LoadScene(curGame.GetComponentInChildren<TextMeshProUGUI>().text, LoadSceneMode.Single);
    }

}
