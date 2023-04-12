using UnityEngine.SceneManagement;
using UnityEngine;


public class MenuEvents : MonoBehaviour
{
    //public void play()
    //{
    // scenemanager.loadscene("playscene");
    //}

    //public void Quit(){
    //    Debug.Log("Salir...");
    //    Application.Quit();
    //}

    public void LoadLevel(int index) => SceneManager.LoadScene(index);
}

