using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public enum GameState {
    PLAYING, PAUSED, NONE
}

public class GameManager : MonoBehaviour
{
    public CharacterControl playerInfo;
    public PlayerInput playerInput;
    public Inventory inventory;
    public GameObject playerCamera;

    private PostProcessVolume volume;
    private float playerHealth = 1.0f;
    private float playerInsanity = 0.0f;
    private int playerAmmo;
    private GameState gameState;
    private float healingValue = 0.0f;
    private float healingDelay = 0.3f;
    private bool healing = false;
    private float insanityValue = 0.0f;
    private float insanityDelay = 0.3f;
    private bool insanitying = false;
    [SerializeField]
    private float jumpscareAppearance;
    private float jumpscareTimer = 0f;

    //Singleton
    public static GameManager Instance { get; private set; }

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


    private void Start() {
        gameState = GameState.PLAYING;
        volume = playerCamera.GetComponent<PostProcessVolume>();
        //playerInput.actions.Enable();
    }

    private void Update() {
        if (playerInsanity >= 0.8) {
            jumpscareTimer += Time.deltaTime;
            if (jumpscareTimer >= jumpscareAppearance) {
                jumpscareImage();
                jumpscareTimer = 0;
            }
        }
    }

    public void recoverHealth(float changeInHealth){
        healingValue += changeInHealth;
        if (! healing){
            StartCoroutine(healOverTime(healingDelay));
        }
    }
    
    public void recoverSanity(float sanity){
        insanityValue -= sanity;
        if (! insanitying){
            StartCoroutine(sanityOverTime(insanityDelay));
        }
    }

    public void updateHealth(float changeInHealth)
    {
        playerHealth += changeInHealth;
        playerInfo.changeBasedOnHealth(playerHealth);
        UITestingGM.Instance.changeHealth(changeInHealth);
        Debug.Log(playerHealth);
    }

    public void updateInsanity(float insanity)
    {
        playerInsanity += insanity;
        playerInfo.changeBasedOnInsanity(playerInsanity);
        UITestingGM.Instance.changeSpook(insanity);
        adjustVignette(playerInsanity);
    }

    private void jumpscareImage() {
        int chance = Random.Range(0, 2);
        if (chance == 1) {
            UITestingGM.Instance.showImage();
        }
    }

    private void adjustVignette(float newValue) {
        if (newValue < 0.2f) newValue = 0.2f;
        if (newValue > 0.6f) newValue = 0.6f;

        Vignette vignette; 
        volume.profile.TryGetSettings(out vignette);
        vignette.intensity.value = newValue;
    }

    public void updateInventory()
    {
        inventory.onItemChangedCallback += updateInventory;
        Debug.Log("UPDATING");
    }

    public float getInsanity()
    {
        return playerInsanity;
    }

    IEnumerator healOverTime(float time){
        //Debug.Log("Hit");
        
        healing = true;
        while (healingValue > 0.0f && playerHealth < 1.0f)
        {
            playerHealth += 0.01f;
            healingValue -= 0.01f;
            playerInfo.changeBasedOnHealth(playerHealth);
            UITestingGM.Instance.changeHealth(0.01f);
            yield return new WaitForSeconds(time);
        }
        if (playerHealth > 1.0f){
            playerHealth = 1.0f;
        }
        healingValue = 0.0f;
        healing = false;
        
        //Debug.Log("Not Hit");
    }

    IEnumerator sanityOverTime(float time)
    {
        Debug.Log(insanityValue);
        Debug.Log(playerInsanity);

        insanitying = true;
        while (insanityValue > 0.0f && playerInsanity > 0.0f)
        {

            Debug.Log("recoverying");
            playerInsanity -= 0.01f;
            insanityValue -= 0.01f;
            playerInfo.changeBasedOnInsanity(playerInsanity);
            UITestingGM.Instance.changeSpook(-0.01f);
            adjustVignette(playerInsanity);
            yield return new WaitForSeconds(time);
        }
        if (playerInsanity < 0.0f)
        {
            playerInsanity = 0.0f;
        }
        insanityValue = 0.0f;
        insanitying = false;

        //Debug.Log("Not Hit");
    }


    public  void changeHealDelay(float change){
        healingDelay = change;
    }

    public  void changeSanityDelay(float change){
        insanityDelay = change;
    }

}
