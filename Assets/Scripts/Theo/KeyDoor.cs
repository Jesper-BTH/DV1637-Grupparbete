using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool Key = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        Key = true;
        animator.SetBool("Key", true);
        Debug.Log("Door opened!");
    }
}