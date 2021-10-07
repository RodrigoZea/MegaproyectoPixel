using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    public Inventory inventory;

    InventorySlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        //Subscribed to Change on Inventory
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        //Toggle UI although this is managed from UIGM
    }

    void UpdateUI ()
    {
        UITestingGM.Instance.updateItemList(inventory.itemList);
        for (int i=0; i<slots.Length; i++)
        {
            if(i< inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
