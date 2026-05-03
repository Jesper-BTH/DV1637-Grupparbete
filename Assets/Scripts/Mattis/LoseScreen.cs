using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas Menu;
    private bool FadeIn = false;
    public TMP_Text UsedTime;
    public GameObject Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Time.timeScale = 0;
        FadeIn = true;
        UsedTime.text = "Time played: " + Timer.GetComponent<Matches_Timer>().TotalMatches + "minutes";
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
    void FixedUpdate()
    {
        if (FadeIn)
        {
            //canvas opacity + 1
            //if opacity = 100 FadeIn = false
        }
    }
}
