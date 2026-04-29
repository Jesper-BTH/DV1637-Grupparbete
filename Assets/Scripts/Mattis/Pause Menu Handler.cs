using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuHandler : MonoBehaviour
{
    InputActionMap player;
    InputAction pause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = InputSystem.actions.FindActionMap("Player");
        pause = player.FindAction("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.WasPressedThisFrame())
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            gameObject.transform.GetChild(0).GetComponent<PauseMenu>().Menu.enabled = true;
        }
    }
}
