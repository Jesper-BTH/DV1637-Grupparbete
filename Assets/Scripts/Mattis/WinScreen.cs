using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Canvas Menu;
    public TMP_Text UsedTime;
    public TMP_Text ProgressText;
    public GameObject Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Menu.enabled = false;
    }

    public void Win()
    {
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = false;
        Menu.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        UsedTime.text = "Time played:\n" + ((Timer.GetComponent<Matches_Timer>().TotalMatches*60) - (int)Timer.GetComponent<Matches_Timer>().timer)/60 + " minutes\n" + ((Timer.GetComponent<Matches_Timer>().TotalMatches * 60) - (int)Timer.GetComponent<Matches_Timer>().timer) % 60 + " seconds";
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        //restart scene
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
