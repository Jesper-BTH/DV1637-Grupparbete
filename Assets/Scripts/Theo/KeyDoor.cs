using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool Key = false;
    private Animator animator;

    public AudioSource src;
    public AudioClip sfx1;

    private bool soundPlayed = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        Key = true;
        animator.SetBool("Key", true);

        if (!soundPlayed)
        {
            src.PlayOneShot(sfx1);
            soundPlayed = true;
        }

        Debug.Log("Door opened!");
    }
}