using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum ItemType {
        HEALING,
        AMMO,
        KEY_ITEM,
        OTHER,
        Health,
        Coin,
        Medkit,
    }

    public ItemType itemType;
    public GameObject model;
    public Sprite sprite;
    public int amount;

    public Sprite GetSprite()
    {
        return sprite;
/*        switch (itemType)
        {
            default:
            case ItemType.HEALING: return ItemAssets.Instance.health;
            case ItemType.Coin: return ItemAssets.Instance.coin;
            case ItemType.Medkit: return ItemAssets.Instance.medkit;
        }*/
    }

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Coin:
            case Item.ItemType.AMMO:
            case Item.ItemType.Health:
                return true;
            case Item.ItemType.Medkit:
            case Item.ItemType.KEY_ITEM:
                return false;
        }
    }
}
