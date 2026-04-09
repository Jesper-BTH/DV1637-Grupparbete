using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;
    public float range = 3f;
    public Inventory inventory;

    void Update()
    {
        // Interact with E
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryInteract(InteractionType.Interact);
        }

        // Dig / Hit with Left Click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (inventory.HasItem(ItemType.Shovel))
                TryInteract(InteractionType.Dig);
            else
                TryInteract(InteractionType.Hit);
        }
    }

    void TryInteract(InteractionType type)
    {
        // Shoot ray from center of screen
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        // Debug line to visualize ray
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 1f);

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Debug.Log("Ray hit: " + hit.collider.name);
            Debug.Log("Component: " + hit.collider.GetComponent<IInteractable>());

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
                interactable.Interact(this, type);
        }
    }
}