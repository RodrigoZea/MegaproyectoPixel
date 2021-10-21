using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState {
    PLAYING, PAUSED, NONE
}

public class GameManager : MonoBehaviour
{
    public CharacterControl playerInfo;
    public PlayerInput playerInput;
    public Inventory inventory;

    private float playerHealth = 1.0f;
    private float playerInsanity = 1.0f;
    private int playerAmmo;
    private GameState gameState;
    private float healingValue = 0.0f;
    private float healingDelay = 0.5f;
    private bool healing = false;
    private float insanityValue = 0.0f;
    private float insanityDelay = 0.5f;
    private bool insanitying = false;

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
        //playerInput.actions.Enable();
    }

    private void Update() {
        
    }

    public void recoverHealth(float changeInHealth){
        healingValue += changeInHealth;
        if (! healing){
            StartCoroutine(healOverTime(healingDelay));
        }
    }
    
    public void recoverSanity(float sanity){
        insanityValue += sanity;
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
        //Debug.Log("Hit");

        insanitying = true;
        while (insanityValue > 0.0f && playerHealth > 0.0f)
        {
            playerInsanity -= 0.01f;
            insanityValue += 0.01f;
            playerInfo.changeBasedOnInsanity(playerInsanity);
            UITestingGM.Instance.changeSpook(-0.01f);
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

}
