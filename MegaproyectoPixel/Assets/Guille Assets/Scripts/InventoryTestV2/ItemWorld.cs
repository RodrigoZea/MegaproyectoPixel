using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public Item item;
    private Sprite sprite;
    private GameObject model;    
    
    public string key { get; }

    public void SetItem(Item item)
    {
        this.item = item;
        sprite = item.GetSprite();
        model = item.GetObject();
    }

    public Item GetItem()
    {
        return item;
    }

    public Item OnInteract()
    {
        return GetItem();
    }
}

