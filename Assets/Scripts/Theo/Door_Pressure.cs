using UnityEngine;

public class Door_Pressure : MonoBehaviour
{
    public PressurePlate[] plates;
    public Transform door;
    public Vector3 openOffset = new Vector3(0, 5, 0);
    public float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;

    void Start()
    {
        closedPos = door.position;
        openPos = closedPos + openOffset;
    }
    void Update()
    {
        if(AreAllPlatesPressed())
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    bool AreAllPlatesPressed()
    {
        foreach (PressurePlate plate in plates)
        {
            if (!plate.isPressed)
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
