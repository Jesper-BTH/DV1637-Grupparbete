using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas Menu;
    public Canvas Setting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Menu.enabled = false;
        Setting.enabled = false;
    }


    public void Resume()
    {
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Menu.enabled = false;
        Setting.enabled = false;
    }//resumes game
    public void Restart()
    {
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        //restart scen
    }

    public void Settings()
    {
        Menu.enabled = false;
        Setting.enabled = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        GameObject.Find("Player")
            .transform.GetChild(3)
            .GetComponent<MouseLook>()
            .enabled = false;
    }// -Theo

    public void Back()
    {
        Menu.enabled = true;
        Setting.enabled = false;
    }
    public void BackToMenu()
    {
        //GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = true;
        SceneManager.LoadScene(0);//loads mainmenu
    }

    public void Quit()
    {
        Application.Quit();
    }
}
