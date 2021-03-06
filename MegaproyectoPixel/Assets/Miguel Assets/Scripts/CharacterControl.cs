using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Cinemachine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class CharacterControl : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private CharacterAnimation characterAnim;
    [SerializeField]
    private AimOptions aimOptions;
    private Vector3 playerVelocity;
    private Transform cameraTransform;
    private Cinemachine.CinemachineImpulseSource cameraShake;
    private bool groundedPlayer;
    [SerializeField]
    private AudioSource hitSource;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera playerCamera;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera aimCamera;
    [SerializeField]
    private float playerSpeed = 2.0f;
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


    public Inventory inventory;
    private GameObject tempInv;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction aimAction;
    private InputAction shootAction;
    private InputAction sprintAction;
    private InputAction interactAction;
    private InputAction flashlightAction;
    [SerializeField]
    private Light flashlight;
    private bool runPressed = false;
    private bool recovering = false;
    private CinemachineBasicMultiChannelPerlin aimNoise;
    private CinemachineBasicMultiChannelPerlin cameraNoise;
    private SoundChange insanitySound;


    private void Start()
    {
        aimNoise = aimCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cameraNoise = playerCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cameraShake = GetComponent<CinemachineImpulseSource>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        characterAnim = GetComponent<CharacterAnimation>();
        insanitySound = GetComponent<SoundChange>();
        moveAction = playerInput.actions["Move"];
        aimAction = playerInput.actions["Aim"];
        shootAction = playerInput.actions["Shoot"];
        sprintAction = playerInput.actions["Sprint"];
        interactAction = playerInput.actions["Interact"];
        flashlightAction = playerInput.actions["Flashlight"];
        flashlightAction.performed += _ => {flashlight.enabled = !flashlight.enabled;};
        sprintAction.performed += _ => {runPressed = true;};
        sprintAction.canceled += _ => {runPressed = false;};
        shootAction.performed += _ => { weapon.StartFiring(); };
        shootAction.canceled += _ => { };
        shootAction.Disable();
        aimAction.performed += _ => characterAnim.enableAimLayer();
        aimAction.performed += _ => {if (!weapon.isReloading) {shootAction.Enable();} speedLimit = walkSpeed; aimTarget.Aiming();};
        aimAction.canceled += _ => characterAnim.disableAimLayer();
        aimAction.canceled += _ => {shootAction.Disable(); speedLimit = runSpeed; aimTarget.NotAiming();};
        interactAction.performed += _ => interact.Interact();

        cameraTransform = Camera.main.transform;
        inventory = Inventory.instance;
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

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }


    public void HitReaction(){
        hitSource.Play();
        //StartCoroutine(recovery(recoveryTime));
        cameraShake.GenerateImpulse(playerCamera.transform.forward);
        GameManager.Instance.updateInsanity(0.1f);
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
                inventory.removeItem(item);
                GameManager.Instance.recoverHealth(0.20f);
                break;
            case Item.ItemType.Beer:
                inventory.removeItem(item);
                GameManager.Instance.updateHealth(-0.1f);
                GameManager.Instance.recoverSanity(-0.1f);
                break;
            case Item.ItemType.PillBottle:
                inventory.removeItem(item);
                GameManager.Instance.recoverSanity(-0.2f);
                break;
            case Item.ItemType.Syringe:
                inventory.removeItem(item);
                GameManager.Instance.recoverHealth(0.1f);
                GameManager.Instance.updateInsanity(0.1f);
                break;
            case Item.ItemType.Ammo:
                weapon.addAmmo(item.amount);
                inventory.removeItem(item);
                break;
            case Item.ItemType.Note:
                GameManager.Instance.updateInsanity(-0.05f);
                inventory.removeItem(item);
                break;
            case Item.ItemType.Key:
                interact.interactables[0].GetComponent<Door>().locked = false;
                UITestingGM.Instance.ItemLabel(interact.interactables[0]);
                inventory.removeItem(item);
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

    public void changeBasedOnHealth(float health){
        if (health <= 1.0f && health > 0.75f){
            runSpeed = 1.0f;
            walkSpeed = 4.0f;
            aimNoise.m_AmplitudeGain = 1.0f;
            cameraNoise.m_AmplitudeGain = 0.5f;
        }else
        if (health <= 0.75f && health > 0.50f){
            runSpeed = 1.25f;
            walkSpeed = 4.25f;
            aimNoise.m_AmplitudeGain = 1.25f;
            cameraNoise.m_AmplitudeGain = 0.75f;

        }else
        if (health <= 0.50f && health > 0.25f){
            runSpeed = 1.50f;
            walkSpeed = 4.50f;
            aimNoise.m_AmplitudeGain = 1.50f;
            cameraNoise.m_AmplitudeGain = 1.00f;
        }else
        if (health <= 0.25f && health > 0.0f){
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

    public void changeBasedOnInsanity(float sanity){
        if (sanity <= 1.0f && sanity > 0.75f){
            GameManager.Instance.changeHealDelay(1.0f);
            GameManager.Instance.changeSanityDelay(1.0f);
            weapon.changeReloadTime(5.5f);
            weapon.changeShootTime(1.25f);
            insanitySound.SetSound(0.3f);
        }else
        if (sanity <= 0.75f && sanity > 0.50f){
            GameManager.Instance.changeHealDelay(0.75f);
            GameManager.Instance.changeSanityDelay(0.75f);
            weapon.changeReloadTime(4.5f);
            weapon.changeShootTime(1.0f);
            insanitySound.SetSound(0.2f);
        }else
        if (sanity <= 0.50f && sanity > 0.25f){
            GameManager.Instance.changeHealDelay(0.5f);
            GameManager.Instance.changeSanityDelay(0.5f);
            weapon.changeReloadTime(3.5f);
            weapon.changeShootTime(0.75f);
            insanitySound.SetSound(0.1f);
            Debug.Log("aqui");
        }else
        if (sanity <= 0.25f && sanity > 0.0f){
            GameManager.Instance.changeHealDelay(0.2f);
            GameManager.Instance.changeSanityDelay(0.2f);
            weapon.changeReloadTime(2.5f);
            weapon.changeShootTime(0.5f);
            insanitySound.StopSound();
        }
    }

    public void activateControls(){
        moveAction.Enable();
        aimAction.Enable();
        //shootAction.Enable();
        sprintAction.Enable();
        interactAction.Enable();
        aimOptions.startCamera();
    }

    public void deactivateControls(){
        moveAction.Disable();
        aimAction.Disable();
        shootAction.Disable();
        sprintAction.Disable();
        interactAction.Disable();
        aimOptions.stopCamera();
    }
}
