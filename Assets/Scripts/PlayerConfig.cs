using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConfig : MonoBehaviour
{
    public void clicked()
    {
        SceneManager.LoadScene("PlayerInfo", LoadSceneMode.Single);
    }
}
