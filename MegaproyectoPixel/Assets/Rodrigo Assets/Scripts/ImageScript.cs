using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{
    private Image imageComponent;
    private AudioSource audioComponent;
    private bool isShowing;
    private float imageTimer;
    private float generalTimer;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        audioComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing) {
            imageTimer += Time.deltaTime;
            generalTimer += Time.deltaTime;
            if (imageTimer >= 0.2f) {
                int randomOpacity = Random.Range(200, 255);
                imageComponent.color = new Color(1f, 1f, 1f, randomOpacity/225f);
                imageTimer = 0;
            }

            if (generalTimer >= 3f) {
                stopImage();
                generalTimer = 0;
            }
        }
    }
    
    public void startImage() {
        isShowing = true; 
        imageComponent.enabled = true;
        audioComponent.enabled = true;

        audioComponent.Play();
    }

    private void stopImage() {
        isShowing = false;
        audioComponent.Stop();
        imageComponent.enabled = false;
        audioComponent.enabled = false;
        
    }
}
