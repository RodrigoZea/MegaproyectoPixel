using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private CharacterControl player;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        UITestingGM.Instance.showGameWinPanel(true);
        Cursor.lockState = CursorLockMode.None;
        player.deactivateControls();
        Time.timeScale = 0.0f;
    }
}
