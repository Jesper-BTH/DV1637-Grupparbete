using UnityEngine;
using System.Collections;

public class Door_Pressure : MonoBehaviour
{
    public PressurePlate[] plates;
    public Transform door;
    public Vector3 openOffset = new Vector3(0, 5, 0);
    public float speed = 2f;
    private float openDelay = 2f;
    private float timer = 0f;
    private bool hasShownText = false;
    public GameObject textUi;

    private Vector3 closedPos;
    private Vector3 openPos;

    void Start()
    {
        closedPos = door.position;
        openPos = closedPos + openOffset;


    }
    private IEnumerator ShowTextForSeconds()
    {
        textUi.SetActive(true);

        yield return new WaitForSeconds(2f);

        textUi.SetActive(false);
    }
    void Update()
    {
        if (AreAllPlatesPressed())
        {
            timer += Time.deltaTime;

            if (timer >= openDelay)
            {
                OpenDoor();

                if (!hasShownText)
                {
                    StartCoroutine(ShowTextForSeconds());
                    hasShownText = true;
                }
            }
        }
        else
        {
            timer = 0f;
            CloseDoor();

            hasShownText = false; // reset when plates are released
        }
    }

    bool AreAllPlatesPressed()
    {
        foreach (PressurePlate plate in plates)
        {
            if (plate.isPressed != 1)
            {
                return false; // found one not pressed
            }
        }

        return true; // all are pressed
    }

    void OpenDoor()
    {
        door.position = Vector3.Lerp(door.position, openPos, Time.deltaTime * speed);
    }

    void CloseDoor()
    {
        door.position = Vector3.Lerp(door.position, closedPos, Time.deltaTime * speed);
    }
}
