using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class MouseLook : MonoBehaviour
{
    public Slider slider;
    public float mouseSensitivity = 0.1f;
    [SerializeField] InputAction look;

    float xRotation;
    void Start()
    {   
        slider.value = mouseSensitivity;
    }

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
        float xLook = lookValue.x * mouseSensitivity /** Time.deltaTime*/;
        float yLook = lookValue.y * mouseSensitivity /** Time.deltaTime*/; //Removed deltatime - Mattis

        xRotation -= yLook;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (transform.parent != null)
            transform.parent.Rotate(Vector3.up, xLook, Space.World);
        
    }
    // Called by UI slider
    public void SetSensitivity()
    {
        mouseSensitivity = slider.value/5;
    }
}