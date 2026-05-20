using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;
    public float range = 3f;
    public Inventory inventory;
    public GameObject textUi;
    //GameObject itemCarryParent;

    public AudioSource src;
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;


    private IEnumerator ShowTextForSeconds()
    {
        textUi.SetActive(true);

        yield return new WaitForSeconds(2f);

        textUi.SetActive(false);
    }
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

        //if ((Mouse.current.leftButton.wasReleasedThisFrame && itemCarryParent)
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
                Coffin coffin = hit.collider.GetComponentInParent<Coffin>();

                if (coffin != null)
                {
                    coffin.WeakPointHit(hit.collider);
                    src.PlayOneShot(sfx1);
                    return;
                }

                CrackedWall wall = hit.collider.GetComponentInParent<CrackedWall>();
                if (wall != null)
                {
                    wall.WeakPointHit(hit.collider);
                    return;
                }

            }

            Coffin coffinWood = hit.collider.GetComponentInParent<Coffin>();

            if (coffinWood != null)
            {
                src.PlayOneShot(sfx2);
                return;
            }

            /*if (hit.collider.CompareTag("Block") && hit.collider.transform.parent.CompareTag("Broken"))
            {
                itemCarryParent = hit.collider.transform.parent.gameObject;
                hit.collider.transform.SetParent(gameObject.transform.GetChild(3));
            }*/

            // theo
            if (hit.collider.CompareTag("Dirt"))
            {
                if (inventory.HasItem(ItemType.Shovel))
                {
                    Destroy(hit.collider.gameObject);
                    src.PlayOneShot(sfx3);
                    return;
                }
                else
                {
                    StartCoroutine(ShowTextForSeconds());
                }
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