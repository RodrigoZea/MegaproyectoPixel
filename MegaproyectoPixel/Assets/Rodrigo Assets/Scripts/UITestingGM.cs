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
    public ImageScript jumpscareImage;
    public CharacterControl playerController;
    public GameObject highlightedItem;
    [SerializeField]
    private InteractControl interact;
    [SerializeField]
    private GameObject options;
    [SerializeField]
    private float idleTimer;
    [SerializeField]
    private GameObject grabLabel;
    [SerializeField]
    private GameObject NoteCanvas;
    public GameObject NoteBackButton;
    private int sizeWidth;
    private int sizeHeight;
    public Inventory inventory;
    public bool canvasFadeable;
    private float canvasFadeTimer;
    private bool canvasVisible = true;
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
            inventorySlotsContainer.SetActive(true);
            canvasVisible = false;

            inventoryTabsButtons[0].GetComponent<Button>().Select();
            inventoryTabsButtons[0].GetComponent<Button>().OnSelect(null);
            showTab(0);
            Cursor.lockState = CursorLockMode.None;
            playerController.deactivateControls();
            //moveBars(sizeWidth);
            //renderTextureInventory.SetActive(true);
        } else if(inventoryAction.triggered && inventoryShowing && options.activeSelf == false)
        {            
            Cursor.lockState = CursorLockMode.Locked;
            // Hide inventory and show normal UI
            hideNote();
            resetItemHighlighted();
            dehighlightSlots();
            inventoryShowing = false;
            InventoryGroupCanvas.SetActive(false);
            fadeGroupObject.SetActive(true);
            inventorySlotsContainer.SetActive(false);
            canvasVisible = false;
            playerController.activateControls();
        }
    }

    // -------------------------------------------------------------------------------------------------------------------------------

    public void changeHealth(float value) {
        if (bloodDrops.isStopped) {
            bloodDrops.Play();
        }

        if (!canvasVisible) {
            canvasVisible = true;
            fadeGroup.alpha = 1;
        }

        Vector3 updatedHealthScale = new Vector3(healthBar.transform.localScale.x, healthBar.transform.localScale.y + value,  healthBar.transform.localScale.z);

        if (updatedHealthScale.y <= 1.00f && updatedHealthScale.y >= -0.00f) {
            healthBar.transform.localScale = updatedHealthScale;
        }
    }

    public void changeSpook(float value) {
        if (!canvasVisible) {
            canvasVisible = true;
            fadeGroup.alpha = 1;
        }

        Vector3 updatedSpookScale = new Vector3(spookBar.transform.localScale.x, spookBar.transform.localScale.y + value,  spookBar.transform.localScale.z);

        if (updatedSpookScale.y <= 1.00f && updatedSpookScale.y >= -0.00f) {
            spookBar.transform.localScale = updatedSpookScale;
        }
    }

    public void showImage() {
        jumpscareImage.startImage();
    }

    public void hideNote() {
        NoteCanvas.SetActive(false);
        NoteBackButton.SetActive(false);
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

        //Alternative Text for Notes
        if(itemToHighlight.itemType == Item.ItemType.Note)
        {
            if (GameManager.Instance.getInsanity() >= 0.4f)
            {
                Text CurrentObjectDescription = highlightedItem.transform.Find("CurrentObjectDescription").GetComponent<Text>();
                CurrentObjectDescription.text = ("Old ragged note to read.");
                NoteCanvas.GetComponentInChildren<NoteScript>().updateText(""+itemToHighlight.AlternativeDescription);
            }
            else
            {
                Text CurrentObjectDescription = highlightedItem.transform.Find("CurrentObjectDescription").GetComponent<Text>();
                CurrentObjectDescription.text = ("Old ragged note to read.");
                NoteCanvas.GetComponentInChildren<NoteScript>().updateText("" + itemToHighlight.description);
            }
        }
        else
        {
            Text CurrentObjectDescription = highlightedItem.transform.Find("CurrentObjectDescription").GetComponent<Text>();
            CurrentObjectDescription.text = ("" + itemToHighlight.description);

        }

        // Change later :)
        toHighlight.GetComponent<Image>().color = Color.yellow;
        toHighlight.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        //toHighlight.GetComponent<Image>().color = new Color(161f/225f, 159f/225f, 124f/225f);
        inventoryShowActionButtons(itemToHighlight);
    }

    public void ItemLabel(GameObject itemToGrab)
    {
        grabLabel.SetActive(true);
        if (itemToGrab.GetComponent<Door>())
        {
            if (itemToGrab.GetComponent<Door>().locked == false)
            {
                if(itemToGrab.GetComponent<Door>().isOpen == false) {
                    grabLabel.GetComponent<Text>().text = "Press 'F' to open door";
                }
                else
                {
                    grabLabel.GetComponent<Text>().text = "Press 'F' to close door";
                }

            }
            else
            {
                grabLabel.GetComponent<Text>().text = "This door is locked. You need a key to open it.";
            }
        }
        else
        {
            grabLabel.GetComponent<Text>().text = "Press 'F' to grab " + itemToGrab.name;
        }
    }

    public void hideItemLabel()
    {
        grabLabel.SetActive(false);
    }

    private void inventoryShowActionButtons(Item selectedItem) {
        inventoryActionButtons.SetActive(true);
        if (selectedItem.itemType == Item.ItemType.Key)
        {
            GameObject removeGameObject = inventoryActionButtons.transform.Find("DropOption").gameObject;
            removeGameObject.SetActive(false);
            //Si el collider de enfrente del player me devuelve una door y el item que tengo seleccionado es una key
            try
            {
                if (interact.interactables[0].GetComponent<Door>() && selectedItem.door == interact.interactables[0].GetComponent<Door>())
                {
                    GameObject useGameObject = inventoryActionButtons.transform.Find("UseOption").gameObject;
                    useGameObject.SetActive(true);
                }
                else
                {
                    GameObject useGameObject = inventoryActionButtons.transform.Find("UseOption").gameObject;
                    useGameObject.SetActive(false);
                }
            }
            catch
            {
                GameObject useGameObject = inventoryActionButtons.transform.Find("UseOption").gameObject;
                useGameObject.SetActive(false);
            }

        } else if (selectedItem.itemType == Item.ItemType.Note)
        {

            GameObject useGameObject = inventoryActionButtons.transform.Find("UseOption").gameObject;
            useGameObject.SetActive(true);
            

            GameObject removeGameObject = inventoryActionButtons.transform.Find("DropOption").gameObject;
            removeGameObject.SetActive(false);

        } else
        {
            //Si no es una llave se activan todas las opciones
            GameObject useGameObject = inventoryActionButtons.transform.Find("UseOption").gameObject;
            useGameObject.SetActive(true);

            GameObject removeGameObject = inventoryActionButtons.transform.Find("DropOption").gameObject;
            removeGameObject.SetActive(true);
        }

        Button useButton = inventoryActionButtons.transform.Find("UseOption").GetComponent<Button>();
        useButton.onClick.RemoveAllListeners();
        useButton.onClick.AddListener(delegate { useItem(selectedItem); });

        Button removeButton = inventoryActionButtons.transform.Find("DropOption").GetComponent<Button>();
        removeButton.onClick.RemoveAllListeners();
        removeButton.onClick.AddListener(delegate { removeItem(selectedItem); });     
    }

    private void useItem(Item selectedItem)
    {
        if(selectedItem.itemType == Item.ItemType.Note)
        {
            NoteCanvas.SetActive(true);
            NoteBackButton.SetActive(true);
        }
        else {
            playerController.UseItem(selectedItem);
        }
        inventoryActionButtons.SetActive(false);
        inventorySlotsContainer.SetActive(true);
        resetItemHighlighted();
        dehighlightSlots();
    }

    private void removeItem(Item selectedItem)
    {
        inventory.removeItem(selectedItem);
        inventoryActionButtons.SetActive(false);
        inventorySlotsContainer.SetActive(true);
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
            otherSlot.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    // Ask for index in editor and show that tab index and hide every other tab. Thats the solution.
    public void showTab(int index) {
        for(int i=0;i<inventoryTabs.Length;i++){
            inventoryTabs[i].SetActive(false);
            inventoryTabsButtons[i].transform.GetChild(0).GetComponent<Text>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
            
        }

        inventoryTabsButtons[index].transform.GetChild(0).GetComponent<Text>().color = new Color(225f/225f, 189f/225f, 0f/225f);
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
