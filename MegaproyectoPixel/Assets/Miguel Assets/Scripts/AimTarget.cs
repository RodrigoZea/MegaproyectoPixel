using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTarget : MonoBehaviour
{
    [SerializeField]
    Transform mainCamera;
    [SerializeField]
    Transform alternatePoint;
    Ray ray;
    RaycastHit hitInfo;
    private bool aiming = false;

    // Update is called once per frame
    void Update()
    {   
        if (aiming){
            ray.origin = mainCamera.position;
            ray.direction = mainCamera.forward;
            if (Physics.Raycast(ray, out hitInfo)){
                transform.position = hitInfo.point;
            } else {
                transform.position = alternatePoint.position;
            }
        }
    }

    public void Aiming() {
        aiming = true;
    }

    public void NotAiming(){
        aiming = false;
    }
}
