using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas Menu;
    public bool FadeIn = false;
    public TMP_Text UsedTime;
    public TMP_Text ProgressText;
    public GameObject Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadeIn = false;
        Menu.enabled = false;
    }

    /*public void Lose()
    {
        Cursor.visible = true;
        Time.timeScale = 0;

    }*/

    public void Lose()
    {
        Menu.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        FadeIn = true;
        UsedTime.text = "Time played: " + Timer.GetComponent<Matches_Timer>().TotalMatches + "minutes";
        //ProgressText.text = list of checkpoints
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        //restart scen
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        //change scen to main menu
    }

    public void Quit()
    {
        Application.Quit();
    }
    void Update()
    {
        if (FadeIn)
        {
            Menu.GetComponent<CanvasGroup>().alpha += Time.deltaTime*0.5f;
            if (Menu.GetComponent<CanvasGroup>().alpha >= 1)
            {
                Time.timeScale = 0;
                FadeIn = false;
            }
            //canvas fade in effect
        }
    }
}
