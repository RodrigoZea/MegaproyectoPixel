using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNormalJumpscare : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        UITestingGM.Instance.showImage();
    }

    private void OnTriggerExit(Collider other) {
        Destroy(gameObject);
    }
}
