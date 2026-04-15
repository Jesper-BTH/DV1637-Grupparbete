using Unity.VisualScripting;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    int PointsHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PointsHit = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WeakPointHit(Collider piece)
    {
        PointsHit++;
        piece.transform.tag = "Broken";
        piece.transform.Translate(0,0.02f,0);//Feedback on weakhit
        Debug.Log("Pointhit: " +  PointsHit);
        
        if(PointsHit >= 3)
        {
            int kids = gameObject.transform.childCount;
            for (int i = 0; i < kids; i++)
            {
                Debug.Log(gameObject.transform.GetChild(i));
                gameObject.transform.GetChild(i).AddComponent<Rigidbody>();
                gameObject.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
                gameObject.transform.GetChild(i).AddComponent<BoxCollider>();

                gameObject.transform.GetChild(i).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f)), ForceMode.Impulse);
            }//Scatter pieces
            gameObject.transform.GetComponent<BoxCollider>().enabled = false;
        }//breaks the object into pieces when 3 weakpoints have been hit.

    }
}
