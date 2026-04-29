using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public void OpenDoor()
    {
        Destroy(gameObject);
        Debug.Log("Door opened!");
        //gameObject.SetActive(false); // or animation
    }
}