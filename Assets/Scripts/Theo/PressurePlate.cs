using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int isPressed = 0;
    private Animator animator;

    public AudioSource src;
    public AudioClip sfx1;


    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            isPressed++;
            animator.SetInteger("isPressed", isPressed);

            src.PlayOneShot(sfx1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            isPressed--;

            if (isPressed < 0)
                isPressed = 0;

            animator.SetInteger("isPressed", isPressed);

        }
    }
}