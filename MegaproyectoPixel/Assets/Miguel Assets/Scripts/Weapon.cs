using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform raycastOrigin;
    [SerializeField]
    private Transform raycastDestiny;
    [SerializeField]
    private float recoveryTime = 0.8f;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera aimCamera;
    [SerializeField]
    private float verticaRecoil, duration;
    private float time = 0;
    private Ray ray;
    private RaycastHit hitInfo;
    private bool firing = false;
    private bool fireAvailable = true;

    void Update() {
        if (fireAvailable && firing){
            Fire();
        }
        if (time > 0){
            aimCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value -= verticaRecoil * Time.deltaTime;
            time -= Time.deltaTime;
        }
    }

    private void Fire(){
        Debug.Log("Fire");
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestiny.position - raycastOrigin.position;
        if(Physics.Raycast(ray, out hitInfo)){
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            Debug.Log("Hit");
        }
        time = duration;
        StartCoroutine(recovery(recoveryTime));
    }

    public void StartFiring() {
        firing = true;
    }

    public void StopFiring(){
        firing = false;
    }

    IEnumerator recovery(float time){
        fireAvailable = false;
        yield return new WaitForSeconds(time);
        fireAvailable = true;
    }
}
