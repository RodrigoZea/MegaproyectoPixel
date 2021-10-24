using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEnemy : MonoBehaviour
{
    private bool canShootRay=false;
    private RaycastHit highlightInfo;
    [SerializeField]
    private Transform raycastOrigin;
    private Ray rayHighlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    /*         if (canShootRay) {
            rayHighlight.origin = raycastOrigin.position;
            rayHighlight.direction = Vector3.back;

            if (Physics.Raycast(rayHighlight, out highlightInfo, 3.0f)){ 
                Debug.DrawLine(rayHighlight.origin, highlightInfo.point, Color.yellow, 2.0f);

                if (highlightInfo.collider.tag == "WindowEnemy"){
                    Debug.Log("holla");
                }
            }
        } */
    }

    private void OnTriggerEnter(Collider other) {
        /*         if (other.tag == "WindowEvent") {
            canShootRay = true;
        } */
        if (other.tag == "WindowEvent") {
            other.gameObject.GetComponentInChildren<AudioSource>().Play();
            other.gameObject.GetComponentInChildren<Light>().enabled = true;
        } 
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "WindowEvent") {
            Destroy(other.gameObject);
        } 
    }

}
