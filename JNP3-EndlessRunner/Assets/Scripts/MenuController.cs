using UnityEngine;

public class MenuController : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "Game";

    [SerializeField]
    private SceneLoader sceneLoader;

    public void PlayGame()
    {
        sceneLoader.LoadScene(GAME_SCENE_NAME);
    }

    public void QuitGame()
    {
        Debug.Log("APPLICATION QUIT");
        Application.Quit();
    }
}
