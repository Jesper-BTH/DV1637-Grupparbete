using UnityEngine;

public class CodeLockDoor : MonoBehaviour
{
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3f, 0);
    [SerializeField] private float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool open;

    // Audio Jesper
    public AudioSource src;
    public AudioClip sfx1;
    private bool soundPlayed = false;

    private void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + openOffset;
    }

    public void Open()
    {
        open = true;

        if (!soundPlayed)
        {
            src.pitch = 1;
            src.clip = sfx1;
            src.time = 0;
            src.Play();

            soundPlayed = true;
        }
    }
    public void Close()
    {
        open = false;

        if (soundPlayed)
        {
            src.pitch = -1;
            src.clip = sfx1;
            src.time = sfx1.length - 0.01f;
            src.Play();

            soundPlayed = false;
        }
    }

    private void Update()
    {
        Vector3 target = open ? openPos : closedPos;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }
}