using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryV2
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    
    public InventoryV2()
    {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Coin, amount = 10 });
        AddItem(new Item { itemType = Item.ItemType.Health, amount = 1 });
    }

    public void AddItem(Item item)
    {
        if(item.isStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if(inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
