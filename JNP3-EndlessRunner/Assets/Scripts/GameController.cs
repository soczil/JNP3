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

    private ulong points = 0;

    void Update()
    {
        currentScore.text = points.ToString();
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
}