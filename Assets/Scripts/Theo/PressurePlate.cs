using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int isPressed = 0;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            isPressed++;

            animator.SetInteger("isPressed", isPressed);
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