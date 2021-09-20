using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    private RaycastHit hitInfo;
    private bool firing = false;
    private bool fireAvailable = true;
    float verticaRecoil, horizontalRecoil;
    int index;


    //Shooting mechanic
    [SerializeField]
    private PlayerInput playerInput;

    private InputAction shootAction;
    private InputAction reloadAction;


    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    bool isShooting = false;
    [SerializeField]
    int ammo = 15;
    [SerializeField]
    int magazine = 10;
    [SerializeField]
    int fullMagSize = 10;
    [SerializeField]
    float shootTimer = 0.5f;
    [SerializeField]
    AudioSource shootSound;
    [SerializeField]
    GameObject hit_fx;
    [SerializeField]
    GameObject bullet_hole;
    [SerializeField]
    private Text magText;

    private bool hold;

    private void Start()
    {
        hold = false;
        playerInput = GetComponentInParent<PlayerInput>();
        shootAction = playerInput.actions["Shoot"];
        shootAction.performed += _ => { StartFiring(); hold = true; };
        shootAction.canceled += _ => { hold = false; };
        reloadAction = playerInput.actions["Reload"];
        reloadAction.performed += _ => Reload();
        magText.text = ("" + magazine);
    }

    void Awake() {
        cameraShake = GetComponent<CinemachineImpulseSource>();  
    }
    void Update() {
        if (hold)
            StartFiring();
    }

    private int NextIndex(int index) {
        return (index + 1) % pattern.Length;
    }
    public void StartFiring() {
        
        //Logica de Raycast con el boton de raycast
        if (!isShooting && magazine > 0)
        {
            StartCoroutine("ShootingMechanics", shootTimer);
            Ray ray = new Ray();
            RaycastHit hit;
            ray.origin = raycastOrigin.position;
            ray.direction = raycastDestiny.position - raycastOrigin.position;
            time = duration;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                //Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
                //Si pega a algo
                if (hit.collider)
                {
                    Debug.Log("Hit");
                    GameObject hitFX = Instantiate(hit_fx, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    GameObject bulletFX = Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                }
                cameraShake.GenerateImpulse(aimCamera.transform.forward);
                horizontalRecoil = pattern[index].x;
                verticaRecoil = pattern[index].y;
                //Debug.Log(horizontalRecoil + ", " + verticaRecoil);
                index = NextIndex(index);
                StartCoroutine(recovery(recoveryTime));
            }

            if (time > 0)
            {
                aimCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.Value -= (verticaRecoil * Time.deltaTime) / duration;
                aimCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value -= (horizontalRecoil * Time.deltaTime) / duration;
                time -= Time.deltaTime;
            }                        
            
        }
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

        magText.text = ("" + magazine);
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
                if (ammo >= fullMagSize)
                {
                    ammo -= fullMagSize;
                    magazine = fullMagSize;
                } //Si tiene balas pero no suficientes para cargar todo
                else
                {
                    magazine = ammo;
                    ammo = 0;
                }
            }
        }
        else if (magazine > 0)
        {
            if (ammo > 0)
            {
                //Si tiene suficientes balas para recargar todo el cartucho
                if (ammo >= fullMagSize)
                {
                    ammo = ammo - (fullMagSize-magazine);
                    magazine = fullMagSize;
                } //Si tiene balas pero no suficientes para cargar todo
                else
                {
                    if (magazine + ammo >= fullMagSize)
                    {
                        ammo = ammo - (fullMagSize - magazine);
                        magazine = fullMagSize;
                    }
                    else
                    {
                        magazine = ammo;
                        ammo = 0;
                    }
                }
            }
            else
            {

            }
        }
        magText.text = (""+magazine);
    }

}
