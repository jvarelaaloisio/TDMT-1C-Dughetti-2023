using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene("Level_01");
    }

    public void OpenCredits()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        //TODO: TP2 - Fix - Application.Quit();
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
