using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private bool isActive;
    private void Start()
    {
        pauseScreen.SetActive(false);
        isActive = false;
    }
    private void Update()
    {
        OpenMenu();
    }
    private void OpenMenu()
    {
        if(Input.GetKey(KeyCode.Escape) && isActive == false)
        {
            //Time.timeScale = 0;
            pauseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isActive = true;
        }
        else if (Input.GetKey(KeyCode.Escape) && isActive)
        {
            //Time.timeScale = 1;
            pauseScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isActive = false;
        }
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene("0. Main Menu");
    }
}
