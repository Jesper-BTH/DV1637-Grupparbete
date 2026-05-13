using UnityEngine;
using UnityEngine.UI;

public class BoneButtons : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.9f;
    }

 
}
