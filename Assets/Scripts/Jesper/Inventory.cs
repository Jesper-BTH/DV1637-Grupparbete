using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Shovel,
    Key,
    Matches,
    Rock,
    Map
}

public class Inventory : MonoBehaviour
{
    public List<ItemType> items = new List<ItemType>();

    public void AddItem(ItemType item)
    {
        items.Add(item);
        Debug.Log("Picked up: " + item);
    }

    public bool HasItem(ItemType item)
    {
        return items.Contains(item);
    }
}
