using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    // Params for light
    public float flashTimeLimit;
    public Material dimLight;
    private Light lampLight;
    public MeshRenderer meshRenderer;
    private float flashTimer;
    private bool initialFlash = true;
    private Material initialMaterial;

    void Start()
    {
        lampLight = GetComponentInChildren<Light>();
        //meshRenderer =  transform.GetChild(0).GetComponent<MeshRenderer>();
        initialMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        flashTimer += Time.deltaTime;
        if (flashTimer >= flashTimeLimit) {
            FlashLight();
        }
    }

    void FlashLight() {
        if (initialFlash) {
            lampLight.enabled = false;
            meshRenderer.material = dimLight;
            initialFlash = false;
        } else {
            lampLight.enabled = true;
            meshRenderer.material = initialMaterial;
            initialFlash = true;            
        }

        flashTimer = 0;
    }
}
