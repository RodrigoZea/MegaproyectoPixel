using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform raycastOrigin;

    private Ray ray;
    private RaycastHit hitInfo;
    public void StartFiring() {
        Debug.Log("Fire");
        ray.origin = raycastOrigin.position;
        ray.direction = raycastOrigin.forward;
        if(Physics.Raycast(ray, out hitInfo)){
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            Debug.Log("Hit");
        }
    }

    public void StopFiring(){

    }
}
