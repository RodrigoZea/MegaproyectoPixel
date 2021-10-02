using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UITestingGM : MonoBehaviour
{
    public GameObject fadeGroupObject;
    private CanvasGroup fadeGroup;
    public GameObject healthBar;
    public GameObject spookBar;
    public GameObject player;
    public CharacterControl playerController;
    public UI_Inventory ui_inventory;
    public GameObject highlightedItem;
    [SerializeField]
    private GameObject options;
    [SerializeField]
    private float idleTimer;
    private int sizeWidth;
    private int sizeHeight;
    public InventoryV2 inventory;
    public bool canvasFadeable;
    private float canvasFadeTimer;
    private bool canvasVisible = false;
    private bool updatingValue = false;
    private bool inventoryShowing = false;
    private ParticleSystem bloodDrops;
    private ParticleSystem  spiritDrops;
    private InputAction moveAction;
    // TODO: Refactorize inventory input handling to a separate gamemanager in next iteration.
    private InputAction inventoryAction;
    private InputAction optionsAction;

    // ------------------------------------------------------------------------------------------
    // Inventory
    private List<Item> itemList;
    public GameObject Inventory3D;
    public GameObject InventoryGroupCanvas;
    public GameObject InventoryItemWorldHolder;
    public GameObject[] inventoryTabs;
    public GameObject[] inventoryTabsButtons;
    public Camera renderTextureCam;
    public GameObject renderTextureInventory;
    public GameObject inventorySlotsContainer;
    public GameObject inventoryActionButtons;
    public Sprite defaultSprite;

    //Singleton
    public static UITestingGM Instance { get; private set; }

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        moveAction = player.GetComponent<PlayerInput>().actions["Move"];
        inventoryAction = player.GetComponent<PlayerInput>().actions["Inventory"];
        optionsAction = player.GetComponent<PlayerInput>().actions["Options"];
        fadeGroup = fadeGroupObject.GetComponent<CanvasGroup>();
        bloodDrops = healthBar.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        spiritDrops = spookBar.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        bloodDrops.Stop();
        sizeWidth = Screen.width;
        sizeHeight = Screen.height;
        inventory = playerController.inventory;

        if (canvasFadeable) {
            fadeGroup.alpha = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        if (canvasFadeable) {
            // If player is idle and canvas not visible
            if (!canvasVisible && move.magnitude == 0f) {
                canvasFadeTimer += Time.deltaTime;
                // Fade in
                if (canvasFadeTimer >= idleTimer) {
                    StartCoroutine(fadeGroupFade(fadeGroup.alpha, 1, true));
                }
            // Else if player is moving
            // Hide canvas and reset timer
            } else if (move.magnitude != 0f) {
                // Fade out
                StartCoroutine(fadeGroupFade(fadeGroup.alpha, 0, false));
            }
        }

        if(optionsAction.triggered && options.activeSelf && !inventoryShowing){
            options.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        } else if(optionsAction.triggered && !options.activeSelf && !inventoryShowing) {
            options.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        // TODO: Pass this into a separate method in whatever gamemanager it's going to be handled in...
        if (inventoryAction.triggered && !inventoryShowing && options.activeSelf == false) {
            // Show inventory and hide normal UI
            inventoryShowing = true;
            InventoryGroupCanvas.SetActive(true);
            fadeGroupObject.SetActive(false);
            InventoryItemWorldHolder.SetActive(true);
            canvasVisible = false;

            inventoryTabsButtons[0].GetComponent<Button>().Select();
            inventoryTabsButtons[0].GetComponent<Button>().OnSelect(null);
            showTab(0);
            Cursor.lockState = CursorLockMode.None;
            //moveBars(sizeWidth);
            //renderTextureInventory.SetActive(true);
        } else if(inventoryAction.triggered && inventoryShowing && options.activeSelf == false)
        {            
            Cursor.lockState = CursorLockMode.Locked;
            // Hide inventory and show normal UI
            resetItemHighlighted();
            dehighlightSlots();
            inventoryShowing = false;
            InventoryGroupCanvas.SetActive(false);
            fadeGroupObject.SetActive(true);
            InventoryItemWorldHolder.SetActive(false);
            canvasVisible = false;
            
        }
    }

    // Visibility true means canvas will be shown eventually
    IEnumerator fadeGroupFade(float start, float end, bool visibility) {
        float counter = 0f;

        canvasVisible = visibility;

        while(counter < 2.0f) {
            counter += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(start, end, counter/2.0f);
            canvasFadeTimer = 0f;
            yield return null;
        }
    }

    // -------------------------------------------------------------------------------------------------------------------------------

    public void changeHealth(int value) {
        if (bloodDrops.isStopped) {
            bloodDrops.Play();
        }

        if (!canvasVisible) {
            canvasVisible = true;
            fadeGroup.alpha = 1;
        }

        // Normalize value to 1 max
        float adjustedValue = -0.10f;

        Vector3 updatedHealthScale = new Vector3(healthBar.transform.localScale.x, healthBar.transform.localScale.y + adjustedValue,  healthBar.transform.localScale.z);

        if (updatedHealthScale.y <= 1.1f && updatedHealthScale.y >= -0.1f) {
            healthBar.transform.localScale = updatedHealthScale;
        }
    }

    public void changeSpook(int value) {
        if (!canvasVisible) {
            canvasVisible = true;
            fadeGroup.alpha = 1;
        }

        // Normalize value to 1 max
        float adjustedValue = 0.10f;

        Vector3 updatedSpookScale = new Vector3(spookBar.transform.localScale.x, spookBar.transform.localScale.y + adjustedValue,  spookBar.transform.localScale.z);

        if (updatedSpookScale.y <= 1.1f && updatedSpookScale.y >= -0.1f) {
            spookBar.transform.localScale = updatedSpookScale;
        }
    }

    // -------------------------------------------------------------------------------------------------------------------------------
    public void updateItemList(List<Item> updatedItemList) {
        itemList = updatedItemList;
    }

    public void highlightItem(Item itemToHighlight) {
        dehighlightSlots();
        int highlightedItemIndex = itemList.IndexOf(itemToHighlight);

        GameObject toHighlight = inventorySlotsContainer.transform.GetChild(highlightedItemIndex).gameObject;

        Image CurrentObjectSprite =  highlightedItem.transform.Find("CurrentObjectSprite").GetComponent<Image>();        
        CurrentObjectSprite.sprite = itemToHighlight.GetSprite();

        Text CurrentObjectDescription = highlightedItem.transform.Find("CurrentObjectDescription").GetComponent<Text>();
        CurrentObjectDescription.text = (""+itemToHighlight.description);

        // Change later :)
        toHighlight.GetComponent<Image>().color = Color.yellow;
        //toHighlight.GetComponent<Image>().color = new Color(161f/225f, 159f/225f, 124f/225f);
        inventoryShowActionButtons(itemToHighlight);
    }

    private void inventoryShowActionButtons(Item selectedItem) {
        inventoryActionButtons.SetActive(true);

        Button useButton = inventoryActionButtons.transform.Find("UseOption").GetComponent<Button>();
        useButton.onClick.AddListener(delegate { useItem(selectedItem); });
        Button removeButton = inventoryActionButtons.transform.Find("DropOption").GetComponent<Button>();
        removeButton.onClick.AddListener(delegate { removeItem(selectedItem); } );
        // Set child 0 (use function) to item's UseItem Function
        // Set child 1 (drop function) to item's DropItem/RemoveItem/whatever Function        
    }

    private void useItem(Item selectedItem)
    {
        playerController.UseItem(selectedItem);
        inventoryActionButtons.SetActive(false);
        ui_inventory.RefreshInvetoryItems();
        InventoryItemWorldHolder.SetActive(true);
        resetItemHighlighted();
        dehighlightSlots();
    }

    private void removeItem(Item selectedItem)
    {
        inventory.RemoveItem(selectedItem);
        inventoryActionButtons.SetActive(false);
        ui_inventory.RefreshInvetoryItems();
        InventoryItemWorldHolder.SetActive(true);
        resetItemHighlighted();
        dehighlightSlots();
    }

    private void resetItemHighlighted()
    {
        Image CurrentObjectSprite = highlightedItem.transform.Find("CurrentObjectSprite").GetComponent<Image>();
        CurrentObjectSprite.sprite = defaultSprite;
        Text CurrentObjectDescription = highlightedItem.transform.Find("CurrentObjectDescription").GetComponent<Text>();
        CurrentObjectDescription.text = ("");
    }

    private void dehighlightSlots() {
        inventoryActionButtons.SetActive(false);
        int slots = inventorySlotsContainer.transform.childCount;
        for (int i=0; i < slots; i++) {
            GameObject otherSlot = inventorySlotsContainer.transform.GetChild(i).gameObject;
            otherSlot.GetComponent<Image>().color = Color.white;
        }
    }

    // Ask for index in editor and show that tab index and hide every other tab. Thats the solution.
    public void showTab(int index) {
        for(int i=0;i<inventoryTabs.Length;i++){
            inventoryTabs[i].SetActive(false);
            inventoryTabsButtons[i].transform.GetChild(0).GetComponent<Text>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
        }

        inventoryTabsButtons[index].transform.GetChild(0).GetComponent<Text>().color = Color.white;
        inventoryTabs[index].SetActive(true);        
    }

    private void moveBars(int xReference) {
        Vector3 point = new Vector3();
        GameObject parentHealthBar = healthBar.gameObject.transform.parent.gameObject;
        point = renderTextureCam.ScreenToWorldPoint(
                            new Vector3(
                                xReference - parentHealthBar.transform.position.x - 80, 
                                parentHealthBar.transform.position.y + 40, 
                                renderTextureCam.nearClipPlane + 40
                            ));

        parentHealthBar.transform.position = point;

    }
    
}
