using UnityEngine;

public class WinCon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameObject.Find("Win_Screen").GetComponent<WinScreen>().Win();
            //Victory screen
        }
    }
}
