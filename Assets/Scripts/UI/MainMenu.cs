using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string tutorialScene = "Tutorial";
    [SerializeField] private string creditsScene = "Credits";

    public void PlayGame()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene(tutorialScene);
    }

    public void OpenCredits()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene(creditsScene);
    }

    public void QuitGame()
    {
        //TODO: TP2 - Fix - Application.Quit();
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
