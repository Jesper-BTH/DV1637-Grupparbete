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

        ItemType item =
            inventory.items[inventory.items.Count - 1];

        GameObject prefab = GetPrefab(item);

        if (prefab == null)
        {
            Debug.LogWarning(
                "No prefab found for " + item);
            return;
        }

        Vector3 dropPosition =
            playerCamera.transform.position +
            playerCamera.transform.forward * 2f;

        Instantiate(
            prefab,
            dropPosition,
            Quaternion.identity
        );

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