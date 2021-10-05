using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public List<Item> itemList = new List<Item>();

    public int space = 16;


    public bool addItem(Item item)
    {
        if(itemList.Count >= space)
        {
            return false;
        }
        else
        {
            itemList.Add(item);            
        }
        return true;
    }

    public void removeItem (Item item)
    {
        itemList.Remove(item);
    }

}
