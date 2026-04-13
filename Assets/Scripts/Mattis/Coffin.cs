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

    public void WeakPointHit(GameObject piece)
    {
        PointsHit =+ 1;
        piece.transform.tag = "Broken";
        piece.transform.Translate(0,0.00001f,0);
        
        if(PointsHit >= 3)
        {
            int kids = gameObject.transform.childCount;
            for (int i = 0; i < kids; i++)
            {
                gameObject.transform.GetChild(i).AddComponent<Rigidbody>();
                gameObject.transform.GetChild(i).AddComponent<SphereCollider>();

                gameObject.transform.GetChild(i).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-2, 2), 2,Random.Range(-2, 2)), ForceMode.Impulse);
            }//Scatter pieces
            gameObject.transform.GetComponent<BoxCollider>().enabled = false;
        }//breaks the object into pieces when 3 weakpoints have been hit.

    }
}
