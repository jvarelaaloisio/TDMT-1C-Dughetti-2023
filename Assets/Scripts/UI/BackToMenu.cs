using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        SceneManager.LoadScene("MainMenu");
    }
}
