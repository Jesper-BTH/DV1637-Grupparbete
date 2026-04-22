using UnityEngine;
using UnityEngine.UI;

public class Matches_Timer : MonoBehaviour
{
    public float timer;
    int matches;
    public RawImage match;
    public RawImage fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 300;
        matches = 5; //1 match = 60sec
        Render_Matches();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if ((timer/60)+1 < matches)
        {
            Destroy(gameObject.transform.GetChild(matches + 2));//destroys the most left match
            matches--;            
        }

        fire.transform.position.y = new Vector2(750, -320 + (2 * (timer % matches)));
    }

    void Render_Matches()
    {
        for (int i = gameObject.transform.childCount; i > 2; i--)
        {
            Destroy(gameObject.transform.GetChild(i));//destroys all matches
        }

        for (int i = 1; i < matches; i++)
        {
            Instantiate(match, new Vector2(750 - (i * 60), -320), Quaternion.identity, gameObject.transform);//render out matches to canvas
        }
        Instantiate(fire, new Vector2(750, -320 + (2*(timer%matches))), Quaternion.identity, gameObject.transform);
    }
}
