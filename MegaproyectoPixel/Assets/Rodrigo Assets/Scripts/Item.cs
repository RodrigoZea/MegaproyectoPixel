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
        Key,            //Open Doors
        Note,           //Side Story/Guidance
    }

    public ItemType itemType;
    public Weapon weapon;
    public Door door;
    public Sprite sprite = null;
    [TextArea]
    public String description;
    [TextArea]
    public String AlternativeDescription;
    public int amount;

    public Sprite GetSprite()
    {
        return sprite;
    }

}
