using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    public ItemType itemType;

    public void Interact(PlayerInteraction player, InteractionType type)
    {
        if (type != InteractionType.Interact) return;

        if (itemType == ItemType.Matches)
        {
            GameObject.Find("Player").transform.GetChild(1).GetComponent<Matches_Timer>().addMatch(gameObject.GetComponent<MatchBox>().Amount);
        }//Special case when you pick up a matchbox - Mattis

        player.inventory.AddItem(itemType);
        Destroy(gameObject);

        Debug.Log("Picked up: " + itemType);
    }
}