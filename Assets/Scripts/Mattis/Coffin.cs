using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
        piece.transform.tag = "Block";
        piece.transform.Translate(0,0.06f,0);//Feedback on weakhit
        //Vector3 rotvect = piece.transform.position - GameObject.Find("Player").transform.position;
        //piece.transform.Rotate(Mathf.Atan(10*rotvect.z/rotvect.y), Mathf.Atan(10*rotvect.x/rotvect.z), Mathf.Atan(10*rotvect.y/rotvect.x));
        //piece.transform.Rotate(GameObject.Find("Player").transform.rotation.x+180, GameObject.Find("Player").transform.rotation.y+180, GameObject.Find("Player").transform.rotation.y/10);
        Debug.Log("Pointhit: " +  PointsHit);
        
        if(PointsHit >= 3)
        {
            int kids = gameObject.transform.childCount;
            for (int i = 0; i < kids; i++)
            {
                Debug.Log(gameObject.transform.GetChild(i));
                gameObject.transform.GetChild(i).AddComponent<Rigidbody>();
                gameObject.transform.GetChild(i).GetComponent<Rigidbody>().mass = 3;
                gameObject.transform.GetChild(i).GetComponent<MeshCollider>().enabled = false;
                gameObject.transform.GetChild(i).AddComponent<BoxCollider>();
                //gameObject.transform.GetChild(i).GetComponent<BoxCollider>().size = new Vector3(gameObject.transform.GetChild(i).GetComponent<BoxCollider>().size.x, gameObject.transform.GetChild(i).GetComponent<BoxCollider>().size.y * 6, gameObject.transform.GetChild(i).GetComponent<BoxCollider>().size.z);

                gameObject.transform.GetChild(i).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f)), ForceMode.Impulse);
            }//Scatter pieces
            gameObject.transform.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.tag = "Broken";
        }//breaks the object into pieces when 3 weakpoints have been hit.

    }
}
