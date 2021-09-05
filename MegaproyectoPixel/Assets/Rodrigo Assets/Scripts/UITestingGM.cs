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
    [SerializeField]
    private float idleTimer;
    private int sizeWidth;
    private int sizeHeight;
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

    // ------------------------------------------------------------------------------------------
    // Inventory
    private Item[] itemList = new Item[20];
    public GameObject Inventory3D;
    public GameObject InventoryGroupCanvas;
    public GameObject InventoryItemWorldHolder;
    public GameObject[] inventoryTabs;
    public GameObject[] inventoryTabsButtons;
    public Camera renderTextureCam;
    public GameObject renderTextureInventory;

    // Start is called before the first frame update
    void Start()
    {
        moveAction = player.GetComponent<PlayerInput>().actions["Move"];
        inventoryAction = player.GetComponent<PlayerInput>().actions["Inventory"];
        fadeGroup = fadeGroupObject.GetComponent<CanvasGroup>();
        bloodDrops = healthBar.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        spiritDrops = spookBar.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        bloodDrops.Stop();
        sizeWidth = Screen.width;
        sizeHeight = Screen.height;

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

        // TODO: Pass this into a separate method in whatever gamemanager it's going to be handled in...
        if (inventoryAction.triggered && !inventoryShowing) {
            // Show inventory and hide normal UI
            inventoryShowing = true;
            InventoryGroupCanvas.SetActive(true);
            fadeGroupObject.SetActive(false);
            InventoryItemWorldHolder.SetActive(true);
            canvasVisible = false;

            inventoryTabsButtons[0].GetComponent<Button>().Select();
            inventoryTabsButtons[0].GetComponent<Button>().OnSelect(null);
            showTab(0);
            //moveBars(sizeWidth);
            //renderTextureInventory.SetActive(true);
        } else if(inventoryAction.triggered && inventoryShowing){
            // Hide inventory and show normal UI
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
    public void showInventory() {
        fadeGroup.gameObject.SetActive(false);
        canvasVisible = false;

        Inventory3D.gameObject.SetActive(true);
        InventoryGroupCanvas.gameObject.SetActive(true);
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
