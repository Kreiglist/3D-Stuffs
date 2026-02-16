using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("1. Cubes");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("2. Movements");
    }
    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
