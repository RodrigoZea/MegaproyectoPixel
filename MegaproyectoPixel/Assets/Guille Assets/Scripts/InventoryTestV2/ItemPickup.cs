using UnityEngine;

public class ItemPickup : InteractControl
{
    public Item item;

    public override void Interacting()
    {
        base.Interacting();

        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = Inventory.instance.addItem(item);
        if(wasPickedUp)
            Destroy(gameObject);
    }

}
