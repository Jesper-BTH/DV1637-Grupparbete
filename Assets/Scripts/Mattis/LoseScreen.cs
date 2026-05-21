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
    public GameObject ProgressList;
    public Inventory inventory;
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
        int invSizesub = 0;
        string listProgress;
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = false;
        Menu.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        FadeIn = true;
        UsedTime.text = "Time played:\n" + Timer.GetComponent<Matches_Timer>().TotalMatches + " minutes";//writes out playtime
        listProgress = " \n" + ProgressList.GetComponent<ProgressonList>().Progress;
        if (inventory.HasItem(ItemType.Shovel))
        {
            listProgress += "\nFound the Shovel.";
            invSizesub += 1;
        }

        if (inventory.HasItem(ItemType.Key))
        {
            listProgress += "\nFound the Key.";
            invSizesub += 1;
        }// adds shovel/key to progresslist

        listProgress += "\nFound " + (inventory.items.Count - invSizesub) + " of 9 Matchboxes.";//adds matches to progresslist
        ProgressText.text = listProgress;
        //ProgressText.text = list of checkpoints
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
