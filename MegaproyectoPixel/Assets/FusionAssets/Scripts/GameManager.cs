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

    private float playerHealth;
    private float playerInsanity;
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
    
    public void addHealth(float healing)
    {
        playerHealth += healing;
        playerInfo.changeBasedOnHealth(playerHealth);
    }

    public void decreaseInsanity(float insanity)
    {
        playerInsanity -= insanity;
        playerInfo.changeBasedOnInsanity(playerInsanity);
    }

    public void updateHealth(float damage)
    {
        playerHealth -= damage;
        playerInfo.changeBasedOnHealth(playerHealth);
    }

    public void updateInsanity(float insanity)
    {
        playerInsanity += insanity;
        playerInfo.changeBasedOnInsanity(playerInsanity);
    }
}
