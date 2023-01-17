using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
    public void clicked()
    {
        Debug.Log("click");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
