using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    private InventoryV2 inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private CharacterControl player;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetPlayer(CharacterControl player)
    {
        this.player = player;
    }

    public void SetInventory(InventoryV2 inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInvetoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInvetoryItems();
    }

    public void RefreshInvetoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 175.5f;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            
            itemSlotContainer.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                //Use Item
                //inventory.UseItem(item);
                inventory.HighlightItem(item);
            };/*
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
                //Eliminate Item from inventory
                inventory.RemoveItem(item);
            };*/

            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();            
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                //uiText.SetText(item.amount.ToString());
            }
            else
            {
                //uiText.SetText("");
            }

            x++;
            Debug.Log(x);
            if (x > 7)
            {
                x = 0;
                y--;
            }
            itemSlotContainer.gameObject.SetActive(false);
        }
    }

}
