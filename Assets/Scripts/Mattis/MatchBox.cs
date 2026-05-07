using UnityEngine;

public class MatchBox : MonoBehaviour
{
    public int Amount;
    GameObject match;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        match = gameObject.transform.GetChild(0).gameObject;
        for (int i = 1; i < Amount; i++)
        {
            Instantiate(match, new Vector3(match.transform.position.x + (0.002f*i), match.transform.position.y, match.transform.position.z), Quaternion.identity, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
