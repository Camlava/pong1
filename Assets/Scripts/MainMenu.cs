using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayTwoPlayer()
    {
        ScoreSettings.singlePlayer = false;
        SceneManager.LoadScene("Game");
    }

    public void PlayOnePlayer()
    {
        ScoreSettings.singlePlayer = true;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}