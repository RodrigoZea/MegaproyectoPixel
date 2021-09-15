using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryV2
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private Action<Item> useItemAction;

    public InventoryV2()
    {
        itemList = new List<Item>();
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
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        UITestingGM.Instance.updateItemList(itemList);
    }

    public void RemoveItem(Item item)
    {
        if (item.isStackable())
        {
            Item itemInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInventory = inventoryItem;
                }
            }
            if(itemInventory != null && itemInventory.amount <= 0)
            {
                itemList.Remove(itemInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        UITestingGM.Instance.updateItemList(itemList);
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }
    public void HighlightItem(Item item) {
        UITestingGM.Instance.highlightItem(item);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }

}
