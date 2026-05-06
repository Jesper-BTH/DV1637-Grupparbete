using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    public GameObject textUi;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            textUi.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            textUi.SetActive(false);
        }
    }

}
