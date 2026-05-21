using UnityEngine;

public class ProgressionCheck : MonoBehaviour
{
    public string Name;
    bool havetriggered;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        havetriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!havetriggered && other.CompareTag("Player"))
        {
            havetriggered=true;
            gameObject.GetComponentInParent<ProgressonList>().Progress += "\n" + Name;//adds collider to progress list
        }
    }
    // Update is called once per frame
    
}
