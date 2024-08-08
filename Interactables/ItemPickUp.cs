using UnityEngine;

public class ItemPickUp : Interactables
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool isPickedUp = Inventory.instance.Add(item);
        if (isPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
