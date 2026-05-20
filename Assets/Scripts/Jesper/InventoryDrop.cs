using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[System.Serializable]
public class ItemPrefab
{
    public ItemType itemType;
    public GameObject prefab;
}

public class InventoryDrop : MonoBehaviour
{
    public Inventory inventory;
    public Camera playerCamera;

    public List<ItemPrefab> itemPrefabs =
        new List<ItemPrefab>();

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            DropLastItem();
        }
    }

    void DropLastItem()
    {
        if (inventory.items.Count == 0)
        {
            Debug.Log("Inventory empty");
            return;
        }

        // Senaste item i inventory
        ItemType item =
            inventory.items[inventory.items.Count - 1];

        GameObject prefab = GetPrefab(item);

        if (prefab == null)
        {
            Debug.LogWarning(
                "No prefab found for " + item);
            return;
        }

        Vector3 dropPosition;

        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        // Placera på ytan spelaren tittar på
        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            3f))
        {
            dropPosition =
                hit.point +
                hit.normal * 0.3f;
        }
        else
        {
            // fallback
            dropPosition =
                playerCamera.transform.position +
                playerCamera.transform.forward * 2f;
        }

        GameObject droppedObject =
            Instantiate(
                prefab,
                dropPosition,
                Quaternion.identity
            );

        // Lägg till Rigidbody om den saknas
        Rigidbody rb =
            droppedObject.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb =
                droppedObject.AddComponent<Rigidbody>();
        }

        rb.useGravity = true;
        rb.isKinematic = false;

        // Ignorera spelarens collider
        Collider playerCollider =
            GetComponent<Collider>();

        Collider itemCollider =
            droppedObject.GetComponent<Collider>();

        if (playerCollider != null &&
            itemCollider != null)
        {
            Physics.IgnoreCollision(
                playerCollider,
                itemCollider,
                true
            );
        }

        // Ta bort från inventory
        inventory.RemoveItem(item);

        Debug.Log("Dropped: " + item);
    }

    GameObject GetPrefab(ItemType item)
    {
        foreach (ItemPrefab entry in itemPrefabs)
        {
            if (entry.itemType == item)
            {
                return entry.prefab;
            }
        }

        return null;
    }
}