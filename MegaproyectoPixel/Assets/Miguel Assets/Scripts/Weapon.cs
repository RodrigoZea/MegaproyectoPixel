using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

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


    //Shooting mechanic
    private PlayerInput playerInput;

    private InputAction shootAction;
    private InputAction reloadAction;


    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    bool isShooting = false;
    [SerializeField]
    int ammo = 32;
    [SerializeField]
    int magazine = 32;
    [SerializeField]
    float shootTimer = 0.5f;
    [SerializeField]
    AudioSource shootSound;
    [SerializeField]
    GameObject hit_fx;
    [SerializeField]
    GameObject bullet_hole;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        shootAction = playerInput.actions["Shoot"];
        shootAction.performed += _ => StartFiring();
        //shootAction.canceled
        shootAction.canceled += _ => { };

        reloadAction = playerInput.actions["Reload"];
        reloadAction.performed += _ => Reload();
    }

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
        //Logica de Raycast con el boton de raycast
        if (!isShooting)
        {

            StartCoroutine("ShootingMechanics", shootTimer);
            Ray ray;
            RaycastHit hit;
            if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, 100f))
            {
                //Si pega a algo
                if (hit.collider)
                {
                    GameObject hitFX = Instantiate(hit_fx, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
            }
        }
    }

    public void StopFiring(){
        firing = false;
    }

    IEnumerator recovery(float time){
        fireAvailable = false;
        yield return new WaitForSeconds(time);
        fireAvailable = true;
    }

    IEnumerator ShootingMechanics(float timer)
    {
        if (magazine > 0)
            magazine--;

        isShooting = true;

        shootSound.Play();

        yield return new WaitForSeconds(timer);

        isShooting = false;
    }

    void Reload()
    {

        if (magazine == 0)
        {
            if (ammo > 0)
            {
                //Si tiene suficientes balas para recargar todo el cartucho
                if (ammo > 31)
                {
                    ammo -= 32;
                    magazine = 32;
                } //Si tiene balas pero no suficientes para cargar todo
                else
                {
                    magazine = ammo;
                    ammo = 0;
                }
            }
            else
            {

            }
        }
    }

}
