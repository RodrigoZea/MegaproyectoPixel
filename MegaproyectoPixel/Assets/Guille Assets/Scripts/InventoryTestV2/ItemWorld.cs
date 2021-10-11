using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    
    public Item item;
   
    public Item GetItem()
    {
        return item;
    }

    public Item OnInteract()
    {
        return GetItem();
    }
}

