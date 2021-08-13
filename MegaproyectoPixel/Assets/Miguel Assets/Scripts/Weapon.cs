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
    private Cinemachine.CinemachineImpulseSource cameraShake;
    [SerializeField]
    private float duration;
    [SerializeField]
    private Vector2[] pattern;
    private float time = 0;
    private Ray ray;
    private RaycastHit hitInfo;
    private bool firing = false;
    private bool fireAvailable = true;
    float verticaRecoil, horizontalRecoil;
    int index;

    void Awake() {
        cameraShake = GetComponent<CinemachineImpulseSource>();  
    }
    void Update() {
        if (fireAvailable && firing){
            Fire();
        }
        if (time > 0){
            aimCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value -= (verticaRecoil * Time.deltaTime) / duration;
            aimCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value -= (horizontalRecoil * Time.deltaTime) / duration;
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
        cameraShake.GenerateImpulse(aimCamera.transform.forward);
        horizontalRecoil = pattern[index].x;
        verticaRecoil = pattern[index].y;
        Debug.Log(horizontalRecoil+", "+verticaRecoil);
        index = NextIndex(index);
        StartCoroutine(recovery(recoveryTime));
    }

    private int NextIndex(int index) {
        return (index + 1) % pattern.Length;
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
