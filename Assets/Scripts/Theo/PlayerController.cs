using UnityEngine;
using UnityEngine.InputSystem;


public class PlayercController : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    private float climbingSpeed = 2f;

    public CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public bool isClimbing = false;


    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }
    private void OnDisable()
    {
        moveAction?.action.Disable();
        jumpAction?.action.Disable();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ladder"))
        {
            isClimbing = true;
            playerVelocity.y = 0f; // reset falling

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ladder"))
        {
            isClimbing = false;
        }
    }

    private void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        move = Vector3.ClampMagnitude(move, 1f);

        if(isClimbing == true)
        {
            playerVelocity.y = input.y * climbingSpeed;

            Vector3 climbMove = Vector3.up * playerVelocity.y;

            characterController.Move(climbMove * Time.deltaTime);

            if (groundedPlayer && input.y < 0)
            {
                isClimbing = false;
            }

            return;
        }

        //Jump using WasPressedThisFrame()
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame() && isClimbing == false)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        //Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        //Move
        Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        characterController.Move(finalMove * Time.deltaTime);
    }
}
