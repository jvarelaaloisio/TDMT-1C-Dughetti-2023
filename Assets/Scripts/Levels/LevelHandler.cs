using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    // Endgame 
    [SerializeField] private GameObject defeatObject;
    [SerializeField] private GameObject victoryObject;

    // Main menu
    private string mainMenuScene = "MainMenu";

    // Next level
    [SerializeField] private string currentLevelScene;
    [SerializeField] private string nextLevelScene;

    // Pause
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endgameMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject controlsBanner;
    [SerializeField] private GameObject cheatsMenu;
    [SerializeField] private GameObject bossSpawner;
    private bool showPauseMenu = false;
    private bool showEndgameMenu = false;
    private bool showControls = false;
    private bool showControlsBanner = true;
    private bool showCheats = false;
    private float timePaused = 0f;
    private float timeUnpaused = 1f;

    // Spawners
    [SerializeField] private int defeatedSpawnersToWin;
    private int defeatedSpawners = 0;

    private void Start()
    {
        if (pauseMenu != null) 
            pauseMenu.SetActive(showPauseMenu);

        if (endgameMenu != null)
            endgameMenu.SetActive(showEndgameMenu);

        if (controlsMenu != null)
            controlsMenu.SetActive(showControls);

        if (cheatsMenu != null)
            cheatsMenu.SetActive(showCheats);

        if (controlsBanner != null)
            controlsBanner.SetActive(showControlsBanner);
    }

    public void IncreaseDefeatedSpawnerCount()
    {
        defeatedSpawners++;
        Debug.Log("Defeated spawners: " + defeatedSpawners);

        if (defeatedSpawners == defeatedSpawnersToWin)
            Victory();
    }

    public void GameOver()
    {
        Debug.Log("Reached GameOver");
        HideControls();
        HideCheats();
        ToggleControlsBanner(false);

        Time.timeScale = timePaused;

        victoryObject.SetActive(false);

        endgameMenu.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = timeUnpaused;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void GoToNextLevel()
    {
        Time.timeScale = timeUnpaused;
        SceneManager.LoadScene(nextLevelScene);
    }

    public void RetryLevel()
    {
        Debug.Log("Retry");
        Time.timeScale = timeUnpaused;
        SceneManager.LoadScene(currentLevelScene);
    }

    public void Victory()
    {
        HideControls();
        HideCheats();
        ToggleControlsBanner(false);

        Time.timeScale = timePaused;

        if (defeatObject != null)
            defeatObject.SetActive(false);

        endgameMenu.SetActive(true);
    }

    public void TogglePause()
    {
        HideControls();
        HideCheats();
        ToggleControlsBanner(showPauseMenu);
        if(bossSpawner != null)
            bossSpawner.SetActive(showPauseMenu);

        showPauseMenu = !showPauseMenu;
        Time.timeScale = showPauseMenu ? timePaused : timeUnpaused;
        pauseMenu.SetActive(showPauseMenu);
    }

    public void ToggleShowControls()
    {
        HideCheats();

        if (!isMenuBeingShown())
        {
            ToggleControlsBanner(showControls);

            Debug.Log("Display controls");
            showControls = !showControls;
            controlsMenu.SetActive(showControls);
        }
    }

    public void ToggleShowCheats()
    {
        HideControls();

        if (!isMenuBeingShown())
        {
            ToggleControlsBanner(showCheats);

            Debug.Log("Display cheats");
            showCheats = !showCheats;
            cheatsMenu.SetActive(showCheats);
        }
    }

    private void HideCheats()
    {
        Debug.Log("Hide cheats");
        showCheats = false;
        cheatsMenu.SetActive(showCheats);
    }

    private void HideControls()
    {
        Debug.Log("Hide controls");
        showControls = false;
        controlsMenu.SetActive(showControls);
    }

    private void ToggleControlsBanner(bool show)
    {
        Debug.Log("Toggle controls banner. Status: " + show);
        showControlsBanner = show;
        controlsBanner.SetActive(showControlsBanner);
    }

    private bool isMenuBeingShown()
    {
        return showPauseMenu || showEndgameMenu;
    }
}
