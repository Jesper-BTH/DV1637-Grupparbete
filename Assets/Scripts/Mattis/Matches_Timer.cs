using UnityEngine;
using UnityEngine.UI;

public class Matches_Timer : MonoBehaviour
{
    public float timer;
    public int TotalMatches = 5;
    public int matches;
    public RawImage match;
    public RawImage fire;
    bool isOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOver = false;
        timer = (TotalMatches * 60) + 1;
        matches = TotalMatches + 1; //1 match = 60sec
        Render_Matches();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !isOver)
        {
            isOver = true;
            GameObject.Find("Lose_screen").GetComponent<LoseScreen>().Lose();
            //gameover
        }

        if (((timer - 2) / 60) + 1 < matches)
        {
            gameObject.transform.parent.GetChild(0).transform.GetComponent<Light>().intensity -= Time.deltaTime;//light goes out between matches
        }
        /*else if (((timer + 1) / 60) + 1 < matches)
        {
            gameObject.transform.GetChild(0).transform.GetComponent<Light>().intensity += Time.deltaTime*2;
        }*/

        if ((timer/60)+1 < matches)
        {
            Destroy(gameObject.transform.GetChild(matches-1).gameObject);//destroys the most left match
            matches--;
            if (timer > 2)
            {
                gameObject.transform.parent.GetChild(0).transform.GetComponent<Light>().intensity = 2; // new match gives light
            }
        }

        if (timer > 0)
        {
            fire.rectTransform.position = new Vector2(match.transform.position.x - ((matches - 1) * 60), match.transform.position.y + (3 * (timer % 60) * Screen.height / 1080));//moves the flame
        }
        
    }

    void Render_Matches()
    {
        for (int i = gameObject.transform.childCount-2; i > 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);//destroys all matches
        }

        for (int i = 1; i < matches; i++)
        {
            Instantiate(match, new Vector2(match.transform.position.x - (i * 60), match.transform.position.y), Quaternion.identity, gameObject.transform);//render out matches to canvas
        }
        //Instantiate(fire, new Vector2(750, -320 + (2*(timer%matches))), Quaternion.identity, gameObject.transform);
        fire.transform.SetSiblingIndex(gameObject.transform.childCount);
        //Debug.Log(gameObject.transform.GetChild(matches));
    }

    public void addMatch(int amount)
    {
        timer += 60 * amount;
        matches += amount;
        TotalMatches += amount;
        Render_Matches();
    }
    
}
