using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [TextArea]
    public String description;
    public int amount;

    public Sprite GetSprite()
    {
        return sprite;
        /*switch (itemType)
        {
            default:
            case ItemType.Beer: return ItemAssets.Instance.beer;
            case ItemType.PillBottle: return ItemAssets.Instance.pills;
            case ItemType.Medkit: return ItemAssets.Instance.medkit;
            case ItemType.Syringe: return ItemAssets.Instance.syringe;
            case ItemType.Ammo: return ItemAssets.Instance.ammo;
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
                return true;
            case Item.ItemType.Ammo:
            case Item.ItemType.Medkit:
            case Item.ItemType.PillBottle:
            case Item.ItemType.Beer:
            case Item.ItemType.Syringe:
                return false;
        }
    }

}
