using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void MainMenu()
    {
        Time.timeScale = 1f; // unpause before changing scenes
        SceneManager.LoadScene("MainMenu");
    }
    public void MainMenuScene()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene("MainMenu");
}
}