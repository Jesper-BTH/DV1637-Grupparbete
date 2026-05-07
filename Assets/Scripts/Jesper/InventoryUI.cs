using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemSlotParent;
    public GameObject itemSlotPrefab;

    public Sprite shovelIcon;
    public Sprite keyIcon;

    private List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        inventory.OnInventoryChanged += UpdateUI;
        UpdateUI();
    }

    void UpdateUI()
    {
        foreach (var slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();

        foreach (var item in inventory.items)
        {
            if (item == ItemType.Matches)
                continue;

            GameObject slot = Instantiate(itemSlotPrefab, itemSlotParent);

            Image icon = slot.transform.Find("Icon").GetComponent<Image>();
            icon.sprite = GetIcon(item);

            slots.Add(slot);
        }
    }

    Sprite GetIcon(ItemType item)
    {
        switch (item)
        {
            case ItemType.Shovel: return shovelIcon;
            case ItemType.Key: return keyIcon;
            default: return null;
        }
    }
}
