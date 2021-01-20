using UnityEngine;
using TMPro;

public class GameController : ASingleton<GameController>
{
    private const string GAME_SCENE_NAME = "Game";
    private const string MENU_SCENE_NAME = "Menu";

    [SerializeField]
    private SceneLoader sceneLoader;

    [SerializeField]
    private TextMeshProUGUI currentScore;

    [SerializeField]
    private TextMeshProUGUI totalScore;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject scoreBar;
    
    [SerializeField]
    private GameObject pauseScreen;

    private ulong points = 0;
    private bool paused = false;

    void Update()
    {
        currentScore.text = points.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void HandleCoinPickedUp(Coin coin)
    {
        if (coin == null)
        {
            return;
        }

        points += coin.Points;
        Debug.LogFormat("Total points: {0}", points);
    }

    public void HandleGameOver()
    {
        scoreBar.SetActive(false);
        totalScore.text = "Score: " + points.ToString();
        gameOver.SetActive(true);
    }

    public void Restart()
    {
        sceneLoader.LoadScene(GAME_SCENE_NAME);
    }

    public void ReturnToMainMenu()
    {
        sceneLoader.LoadScene(MENU_SCENE_NAME);
    }

    private void Pause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0f : 1f;
        pauseScreen.SetActive(paused);
    }
}