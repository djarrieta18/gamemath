using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void play()
    {
        // SceneManager.LoadScene("PlayScene");
    }

    public void Quit(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}

