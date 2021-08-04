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
    [SerializeField]
    private float idleTimer;
    public bool canvasFadeable;
    private float canvasFadeTimer;
    private bool canvasVisible = false;
    private bool updatingValue = false;
    private ParticleSystem bloodDrops;
    private ParticleSystem  spiritDrops;
    private InputAction moveAction;

    // Start is called before the first frame update
    void Start()
    {
        moveAction = player.GetComponent<PlayerInput>().actions["Move"];
        bloodDrops = healthBar.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        spiritDrops = spookBar.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
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
    
}
