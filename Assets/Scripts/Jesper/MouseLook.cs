using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 30f;
    [SerializeField] InputAction look;

    float xRotation;

    void OnEnable()
    {
        look.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        look.Disable();
    }

    void Update()
    {
        Vector2 lookValue = look.ReadValue<Vector2>();
        float xLook = lookValue.x * mouseSensitivity * Time.deltaTime;
        float yLook = lookValue.y * mouseSensitivity * Time.deltaTime;

        xRotation -= yLook;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (transform.parent != null)
            transform.parent.Rotate(Vector3.up, xLook, Space.World);
    }
}