using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    public enum ItemType {
        Medkit,         //+ Vida
        Beer,           //- Insanity, - Vida
        PillBottle,     //- Insanity
        Syringe,        //+ Vida, + Insanity
        Ammo,           //+ Ammo

    }

    public ItemType itemType;
    public Weapon weapon;
    public GameObject model;
    public Sprite sprite;
    public int amount;
    private int position;
    

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

    public GameObject GetObject()
    {
        return model;
    }

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
            case Item.ItemType.Ammo:
                return true;
            case Item.ItemType.Medkit:
            case Item.ItemType.PillBottle:
            case Item.ItemType.Beer:
            case Item.ItemType.Syringe:
                return false;
        }
    }

}
