using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        //inventory.onItemChangeCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI ()
    {

    }
}
