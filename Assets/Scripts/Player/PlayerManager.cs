using UnityEngine.SceneManagement;
using UnityEngine;

using SceneManager2 = UnityEngine.SceneManagement.SceneManager;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static bool isGameWin;
    public GameObject gameWinScreen;
    private void Awake()
    {
        isGameOver = false;
        isGameWin = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        // With this metodo hacemos el llamado a la pop-up  de gameover
    {
        if (isGameOver){
            gameOverScreen.SetActive(true);
        
        }
        if (isGameWin)
        {
            gameWinScreen.SetActive(true);

        }
    }

    public void ReplayLevel()
    {
        SceneManager2.LoadScene(SceneManager2.GetActiveScene().buildIndex);
        
    }
}
