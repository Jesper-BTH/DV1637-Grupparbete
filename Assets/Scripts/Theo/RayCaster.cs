using UnityEngine;
using UnityEngine.InputSystem;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private float range = 5f;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Raycast();
        }
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Dial dial = hit.collider.GetComponentInParent<Dial>();

            if (dial != null)
            {
                dial.Rotate();
            }
        }
    }
}