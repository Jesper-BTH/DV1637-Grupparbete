using TMPro;
using UnityEngine;

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

    private void OnEnable()
    {
        Cursor.visible = true;
        FadeIn = true;
        UsedTime.text = "Time played: " + Timer.GetComponent<Matches_Timer>().TotalMatches + "minutes";
        //ProgressText.text = list of checkpoints
    }

    public void Restart()
    {
        //restart scen
    }

    public void BackToMenu()
    {
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
            Menu.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            if (Menu.GetComponent<CanvasGroup>().alpha >= 1)
            {
                Time.timeScale = 0;
                FadeIn = false;
            }
            //canvas fade in effect
        }
    }
}
