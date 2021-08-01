using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UITestingGM : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public GameObject healthBar;
    public GameObject spookBar;
    public GameObject player;
    public bool canvasFadeable;
    private float canvasFadeTimer;
    private bool canvasVisible = false;
    private ParticleSystem bloodDrops;
    private ParticleSystem  spiritDrops;
    private InputAction moveAction;

    // Start is called before the first frame update
    void Start()
    {
        moveAction = player.GetComponent<PlayerInput>().actions["Move"];
        bloodDrops = healthBar.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        spiritDrops = spookBar.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        bloodDrops.Stop();

        fadeGroup.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        if (canvasFadeable) {
            // If player is idle and canvas not visible
            if (!canvasVisible && move.magnitude == 0f) {
                Debug.Log("Canvas visibile: " + canvasVisible);

                canvasFadeTimer += Time.deltaTime;

                Debug.Log("Canvas fade timer: " + canvasFadeTimer);

                // Fade in
                if (canvasFadeTimer >= 3.0f) {
                    Debug.Log("FADING IN !!!");
                    StartCoroutine(fadeGroupFade(fadeGroup.alpha, 1));
                }
            // Else if player is moving
            // Hide canvas and reset timer
            } else if (move.magnitude != 0f) {
                // Fade out
                Debug.Log("FADING OUT !!!");
                StartCoroutine(fadeGroupFade(fadeGroup.alpha, 0));
            }
        }
    }

    IEnumerator fadeGroupFade(float start, float end) {
        float counter = 0f;

        while(counter < 2.0f) {
            counter += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(start, end, counter/2.0f);
            canvasVisible = !canvasVisible;
            canvasFadeTimer = 0f;
            yield return null;
        }
    }

    // -------------------------------------------------------------------------------------------------------------------------------

    void changeHealth(int value) {
        if (bloodDrops.isStopped) {
            bloodDrops.Play();
        }

        // Normalize value to 1 max
        float adjustedValue = -0.10f;

        Vector3 updatedHealthScale = new Vector3(0, healthBar.transform.localScale.y + adjustedValue, 0);

        if (updatedHealthScale.y <= 1.0f && updatedHealthScale.y >= 0.0f) {
            healthBar.transform.localScale = updatedHealthScale;
        }
    }

    void changeSpook(int value) {

    }
    
}
