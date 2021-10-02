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
    public Sprite sprite;
    [TextArea]
    public String description;
    public int amount;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public bool isStackable()
    {
        switch (itemType)
        {
            default:
                return true;
            case Item.ItemType.Medkit:
            case Item.ItemType.PillBottle:
            case Item.ItemType.Beer:
            case Item.ItemType.Syringe:
            case Item.ItemType.Ammo:
                return false;
        }
    }

}
