using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    public ItemType itemType;

    public void Interact(PlayerInteraction player, InteractionType type)
    {
        if (type != InteractionType.Interact) return;

        player.inventory.AddItem(itemType);
        Destroy(gameObject);

        Debug.Log("Picked up: " + itemType);
    }
}