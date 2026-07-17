using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayTwoPlayer()
    {
        ScoreSettings.singlePlayer = false;
        ScoreSettings.battleMode = false;

        SceneManager.LoadScene("Game");
    }


    public void PlayOnePlayer()
    {
        ScoreSettings.singlePlayer = true;
        ScoreSettings.battleMode = false;

        SceneManager.LoadScene("Game");
    }


    public void PlayBattleMode()
    {
        ScoreSettings.singlePlayer = false;
        ScoreSettings.battleMode = true;

        SceneManager.LoadScene("Game");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}