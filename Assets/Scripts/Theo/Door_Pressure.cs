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

    // Audio Jesper
    public AudioSource src;
    public AudioClip sfx1;
    private bool soundPlayed = false;

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

                // Play sound ONCE
                if (!soundPlayed)
                {
                    src.pitch = 1;
                    src.clip = sfx1;
                    src.time = 0;
                    src.Play();

                    soundPlayed = true;
                }

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

            hasShownText = false;

            if (soundPlayed)
            {
                src.pitch = -1;
                src.clip = sfx1;
                src.time = sfx1.length - 0.01f;
                src.Play();

                soundPlayed = false;
            }
        }
    }

    bool AreAllPlatesPressed()
    {
        foreach (PressurePlate plate in plates)
        {
            if (plate.isPressed != 1)
            {
                return false;
            }
        }

        return true;
    }

    void OpenDoor()
    {
        door.position = Vector3.Lerp(
            door.position,
            openPos,
            Time.deltaTime * speed
        );
    }

    void CloseDoor()
    {
        door.position = Vector3.Lerp(
            door.position,
            closedPos,
            Time.deltaTime * speed
        );
    }
}