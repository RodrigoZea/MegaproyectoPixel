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
    private Cinemachine.CinemachineVirtualCamera aimCamera;
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
    private float runSpeed = 1.0f, walkSpeed = 4.0f;
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
    private CinemachineBasicMultiChannelPerlin aimNoise;
    private CinemachineBasicMultiChannelPerlin cameraNoise;


    private void Start()
    {
        aimNoise = aimCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cameraNoise = playerCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
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
        aimAction.performed += _ => {shootAction.Enable(); speedLimit = walkSpeed; aimTarget.Aiming();};
        aimAction.canceled += _ => characterAnim.disableAimLayer();
        aimAction.canceled += _ => {shootAction.Disable(); speedLimit = runSpeed; aimTarget.NotAiming();};
        interactAction.performed += _ => interact.Interact();
        jumpAction.performed += _ => HitReaction();
        cameraTransform = Camera.main.transform;
        inventory = new InventoryV2();
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
        weapon = GetComponentInChildren<Weapon>();
        Cursor.lockState = CursorLockMode.Locked;
        //changeBasedOnHealth(15.0f);
    }
    void Update()
    {
        
        //Debug.Log(aimAction.phase.ToString());
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

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            /*case Item.ItemType.Health:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Health, amount = 1 });
                break;
            case Item.ItemType.KEY_ITEM:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.KEY_ITEM, amount = 1 });
                break;
            case Item.ItemType.Medkit:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Medkit, amount = 1 });
                break;
            case Item.ItemType.AMMO:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.AMMO, amount = 1 });
                break;*/
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

    public void changeBasedOnHealth(float health){
        if (health <= 100.0f && health > 75.0f){
            runSpeed = 1.0f;
            walkSpeed = 4.0f;
            aimNoise.m_AmplitudeGain = 1.0f;
            cameraNoise.m_AmplitudeGain = 0.5f;
        }else
        if (health <= 75.0f && health > 50.0f){
            runSpeed = 1.25f;
            walkSpeed = 4.25f;
            aimNoise.m_AmplitudeGain = 1.25f;
            cameraNoise.m_AmplitudeGain = 0.75f;
        }else
        if (health <= 50.0f && health > 25.0f){
            runSpeed = 1.50f;
            walkSpeed = 4.50f;
            aimNoise.m_AmplitudeGain = 1.50f;
            cameraNoise.m_AmplitudeGain = 1.00f;
        }else
        if (health <= 25.0f && health > 0.0f){
            runSpeed = 1.75f;
            walkSpeed = 4.75f;
            aimNoise.m_AmplitudeGain = 1.75f;
            cameraNoise.m_AmplitudeGain = 1.25f;
        }

        if (aimAction.phase.ToString() == "Started"){
            speedLimit = walkSpeed;
        }else{
            speedLimit = runSpeed;
        }
    }

    public void changeBasedOnInsanity(float health){

    }
}
