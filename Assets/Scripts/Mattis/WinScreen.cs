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
    public GameObject ProgressList;
    public Inventory inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Menu.enabled = false;
    }

    public void Win()
    {
        int invSizesub = 0;
        string listProgress;
        GameObject.Find("Player").transform.GetChild(3).GetComponent<MouseLook>().enabled = false;
        Menu.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        UsedTime.text = "Time played:\n" + ((Timer.GetComponent<Matches_Timer>().TotalMatches*60) - (int)Timer.GetComponent<Matches_Timer>().timer)/60 + " minutes\n" + ((Timer.GetComponent<Matches_Timer>().TotalMatches * 60) - (int)Timer.GetComponent<Matches_Timer>().timer) % 60 + " seconds";//writes out playtime
        Time.timeScale = 0;
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
        listProgress += "\nEscaped the Graveyard.";
        ProgressText.text = listProgress;
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
        SceneManager.LoadScene(0);//loads mainmenu
    }

    public void Quit()
    {
        Application.Quit();
    }
}
