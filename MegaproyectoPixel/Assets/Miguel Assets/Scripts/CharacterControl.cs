using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class CharacterControl : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private CharacterAnimation characterAnim;
    private Vector3 playerVelocity;
    private Transform cameraTransform;
    private Cinemachine.CinemachineImpulseSource cameraShake;
    private bool groundedPlayer;
    [SerializeField]
    private UI_Inventory uiInventory;    
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera playerCamera;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 2f;
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private InteractControl interact;
    [SerializeField]
    private AimTarget aimTarget;
    [SerializeField]
    [Range(1.0f,3.0f)]
    private float speedFactor = 2.0f, recoveryTime = 1.0f;
    float speedLimit = 1.0f;
    [SerializeField]
    public InventoryV2 inventory;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction aimAction;
    private InputAction shootAction;
    private InputAction sprintAction;
    private InputAction interactAction;
    private bool runPressed = false;
    private bool recovering = false;


    private void Start()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        characterAnim = GetComponent<CharacterAnimation>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        aimAction = playerInput.actions["Aim"];
        shootAction = playerInput.actions["Shoot"];
        sprintAction = playerInput.actions["Sprint"];
        interactAction = playerInput.actions["Interact"];
        sprintAction.performed += _ => {runPressed = true;};
        sprintAction.canceled += _ => {runPressed = false;};
        shootAction.performed += _ => { weapon.StartFiring(); };
        shootAction.canceled += _ => { };
        shootAction.Disable();
        aimAction.performed += _ => characterAnim.enableAimLayer();
        aimAction.performed += _ => {shootAction.Enable(); speedLimit = 4.0f; aimTarget.Aiming();};
        aimAction.canceled += _ => characterAnim.disableAimLayer();
        aimAction.canceled += _ => {shootAction.Disable(); speedLimit = 1.0f; aimTarget.NotAiming();};
        interactAction.performed += _ => interact.Interact();
        jumpAction.performed += _ => HitReaction();
        cameraTransform = Camera.main.transform;
        inventory = new InventoryV2();
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
        weapon = GetComponentInChildren<Weapon>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();

        bool forwardPressed = input.y > 0.0f ? true : false;
        bool rightPressed = input.x > 0.0f ? true : false;
        bool leftPressed = input.x < 0.0f ? true : false;
        bool backPressed = input.y < 0.0f ? true : false;
        playerSpeed = runPressed ? 2.0f / speedLimit : 0.5f / speedLimit;
        characterAnim.changeVelocity(forwardPressed, backPressed, leftPressed, rightPressed, runPressed, playerSpeed);
        characterAnim.lockOrResetVelocity(forwardPressed, backPressed, leftPressed, rightPressed, runPressed, playerSpeed);

        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        controller.Move(move.normalized * Time.deltaTime * playerSpeed*speedFactor);
        
        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            HitReaction();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }


    public void HitReaction(){
        StartCoroutine(recovery(recoveryTime));
        cameraShake.GenerateImpulse(playerCamera.transform.forward);
        
    }

    public void UseItem(Item item)
    {
        //Medkit         //+ Vida
        //Beer           //- Insanity, - Vida
        //PillBottle     //- Insanity
        //Syringe        //+ Vida, + Insanity
        //Ammo           //+ Ammo
        switch (item.itemType)
        {
            case Item.ItemType.Medkit:
                inventory.RemoveItem(item);
                GameManager.Instance.addHealth(1);
                break;
            case Item.ItemType.Beer:
                inventory.RemoveItem(item);
                GameManager.Instance.updateHealth(1);
                GameManager.Instance.decreaseInsanity(1);
                break;            
            case Item.ItemType.PillBottle:
                inventory.RemoveItem(item);
                GameManager.Instance.decreaseInsanity(1);
                break;
            case Item.ItemType.Syringe:
                inventory.RemoveItem(item);
                GameManager.Instance.addHealth(1);
                GameManager.Instance.updateInsanity(1);
                break;
            case Item.ItemType.Ammo:
                inventory.RemoveItem(item);
                weapon.ammo += 1;
                weapon.magText.text = ("" + weapon.magazine + "|" + weapon.ammo);
                break;
        }
    }

    IEnumerator recovery(float time){
        Debug.Log("Hit");
        speedLimit = 4.0f;
        recovering = true;
        yield return new WaitForSeconds(time);
        recovering = false;
        speedLimit = 1.0f;
        Debug.Log("Not Hit");
    }
}
