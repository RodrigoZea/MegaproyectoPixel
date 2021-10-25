using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightsOffJumpscare : MonoBehaviour
{
    [SerializeField]
    private GameObject lightToTurnOff;
    public Material dimLight; 

    private void OnTriggerEnter(Collider other) {
        turnOffLight();

        if (other.GetComponent<CharacterController>())
        {
            UITestingGM.Instance.showImage();
        }
    }

    private void OnTriggerExit(Collider other) {
        Destroy(gameObject);
    }

    private void turnOffLight() {
        lightToTurnOff.GetComponent<FlashingLight>().enabled = false;
        lightToTurnOff.GetComponentInChildren<Light>().enabled = false;
        lightToTurnOff.GetComponentInChildren<MeshRenderer>().material = dimLight;
    }
}

