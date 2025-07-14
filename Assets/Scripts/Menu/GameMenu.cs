using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private bool isActive;

    private string activeScene;
    private void Start()
    {
        activeScene = SceneManager.GetActiveScene().name;
        print(activeScene);
        pauseScreen.SetActive(false);
        isActive = false;
    }
    private void Update()
    {
        OpenMenu();
    }
    private void OpenMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isActive == false)
        {
            if (activeScene == "2. Movements")
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            isActive = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            if (activeScene == "2. Movements")
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            isActive = false;
        }
    }
    public void ReturnToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("0. Main Menu");
    }
}