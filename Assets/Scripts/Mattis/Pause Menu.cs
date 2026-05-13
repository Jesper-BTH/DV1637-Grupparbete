using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Menu.enabled = false;

    }
    public void Restart()
    {
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        //restart scen
    }
    public void BackToMenu()
    {
        //GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = true;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
