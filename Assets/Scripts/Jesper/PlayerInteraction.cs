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
            {
                TryInteract(InteractionType.Dig);
            }
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
            if (hit.collider.CompareTag("Weak"))
            {
                hit.collider.GetComponentInParent<Coffin>().WeakPointHit(hit.collider);
            }//Checks if ray hits a weakpoint and does the weakpscript - Mattis

            //theo
            if (hit.collider.CompareTag("Dirt") && inventory.HasItem(ItemType.Shovel))
            {
                Destroy(hit.collider.gameObject);
                return; // stop further interaction if destroyed
            }
            //theo
            if (hit.collider.CompareTag("KeyDoor") && inventory.HasItem(ItemType.Key))
            {
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    KeyDoor door = hit.collider.GetComponentInParent<KeyDoor>();

                    if (door != null)
                    {
                        door.OpenDoor();
                    }
                }

                return;
            }
            //not theo

            Debug.Log("Ray hit: " + hit.collider.name);
            Debug.Log("Component: " + hit.collider.GetComponent<IInteractable>());

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
                interactable.Interact(this, type);
        }
    }
}