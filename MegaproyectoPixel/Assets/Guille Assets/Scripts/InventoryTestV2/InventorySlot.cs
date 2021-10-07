using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Sprite defaultSprite;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.sprite;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = defaultSprite;
    }


    public void itemHighlight()
    {
        UITestingGM.Instance.highlightItem(item);
    }

}
