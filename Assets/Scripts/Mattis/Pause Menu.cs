using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas Menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Menu.enabled = false;
    }


    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Menu.enabled = false;

    }

    public void BackToMenu()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
