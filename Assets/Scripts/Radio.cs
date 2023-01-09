using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
 
public class Radio : MonoBehaviour
{
    ToggleGroup toggleGroup;
     [SerializeField] private MusicName scriptable;
    void Start()
    {   
       // scriptable = FindObjectOfType<MusicName>();
        toggleGroup = GetComponent<ToggleGroup>();
    }
 
    public void Submit()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.GetComponentInChildren<TextMeshProUGUI>().text);
        if (toggleGroup.name == "MusicSelect"){
            scriptable.changeMusic(toggle.GetComponentInChildren<TextMeshProUGUI>().text);
        }
    }
}