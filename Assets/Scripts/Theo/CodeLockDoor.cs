using UnityEngine;

public class CodeLockDoor : MonoBehaviour
{
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3f, 0);
    [SerializeField] private float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool open;

    private void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + openOffset;
    }

    public void Open()
    {
        open = true;
    }

    private void Update()
    {
        Vector3 target = open ? openPos : closedPos;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }
}