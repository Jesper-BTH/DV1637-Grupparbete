using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool isPressed = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            isPressed = true;
            animator.SetBool("isPressed", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            isPressed = false;
            animator.SetBool("isPressed", false);
        }
    }
}