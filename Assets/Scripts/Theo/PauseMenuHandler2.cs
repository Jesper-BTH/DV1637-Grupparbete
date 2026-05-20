using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuHandler2 : MonoBehaviour
{
    InputActionMap player;
    InputAction pause;

    bool paused = false;

    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] MouseLook mouseLook;

    void Start()
    {
        player = InputSystem.actions.FindActionMap("Player");
        pause = player.FindAction("Pause");
    }

    void Update()
    {
        if (pause.WasPressedThisFrame())
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void Pause()
    {
        paused = true;

        mouseLook.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;

        pauseMenu.Menu.enabled = true;
    }

    void Resume()
    {
        paused = false;

        mouseLook.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;

        pauseMenu.Menu.enabled = false;
        pauseMenu.Setting.enabled = false;
    }
}