using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private string mainMenuScene = "MainMenu";
    public void BackToMainMenu()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene(mainMenuScene);
    }
}