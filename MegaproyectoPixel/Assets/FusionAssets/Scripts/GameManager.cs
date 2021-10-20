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
}
