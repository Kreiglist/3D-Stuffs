using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene("1. Cubes");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("2. Movements");
    }
}
