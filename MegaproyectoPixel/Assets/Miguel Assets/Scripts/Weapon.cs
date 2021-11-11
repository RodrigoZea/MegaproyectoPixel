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
    public bool isReloading = false;
    float verticaRecoil, horizontalRecoil;
    int index;


    //Shooting mechanic
    [SerializeField]
    private PlayerInput playerInput;

    private InputAction shootAction;
    private InputAction reloadAction;
    private InputAction aimAction;
    [SerializeField]
    private Animator rigLayerAnimator;

    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    bool isShooting = false;
    [SerializeField]
    int ammo = 0;
    [SerializeField]
    int magazine = 7;
    [SerializeField]
    int fullMagSize = 7;
    [SerializeField]
    float shootTimer = 0.5f;
    [SerializeField]
    float reloadTimer = 2.5f;
    [SerializeField]
    AudioSource shootSound;
    [SerializeField]
    GameObject hit_fx;
    [SerializeField]
    GameObject bloodhit_fx;
    [SerializeField]
    GameObject bullet_hole;
    [SerializeField]
    Text magText;
    [SerializeField]
    AudioClip shoot, cocked, reload;

    private bool hold;

    private void Start()
    {
        hold = false;
        playerInput = GetComponentInParent<PlayerInput>();
        aimAction = playerInput.actions["Aim"];
        shootAction = playerInput.actions["Shoot"];
        shootAction.performed += _ => { StartFiring(); hold = true; };
        shootAction.canceled += _ => { hold = false; };
        reloadAction = playerInput.actions["Reload"];
        reloadAction.performed += _ => Reload();
        magText.text = ("" + magazine + "|" + ammo);
        if (magazine > 0)
            shootSound.clip = shoot;
        else    
            shootSound.clip = reload;
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

    //FIX ADDAMMO
    public void addAmmo(int extraAmmo)
    {
        if (ammo + extraAmmo <= 14)
        {
            ammo += extraAmmo;
            magText.text = ("" + magazine + "|" + ammo);
        }
        else
        {
            ammo = 20;
            magText.text = ("" + magazine + "|" + ammo);
        }
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
                    if (hit.collider.GetComponent<EnemyAI>() ||  hit.collider.GetComponentInParent<EnemyAI>())
                    {
                        //Personalizacion para pegar enemigos con AI
                        try {
                            hit.collider.GetComponent<EnemyAI>().TakeDamage(1);
                        }
                        catch{
                            hit.collider.GetComponentInParent<EnemyAI>().TakeDamage(1);
                        }
                        
                        //Cambiar a bloodhit_fx y poner particulas de sangre
                        Debug.Log("Hit Life");
                        GameObject hitFX = Instantiate(bloodhit_fx, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    }
                    else
                    {
                        //Solo al pegar a objetos que no sean enemigos instanciar los bulletholes
                        GameObject hitFX = Instantiate(hit_fx, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        GameObject bulletFX = Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                    }
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
            
        } else if (!isShooting && magazine <= 0)
        {
            shootSound.clip = cocked;
            StartCoroutine("playjammedGun", shootTimer);
        }
    }

    IEnumerator playjammedGun(float time)
    {
        isShooting = true;
        shootSound.Play();        
        yield return new WaitForSeconds(time);
        isShooting = false;
    }

    IEnumerator recovery(float time){
        fireAvailable = false;
        yield return new WaitForSeconds(time);
        fireAvailable = true;
    }

    IEnumerator playreload(float time)
    {
        rigLayerAnimator.Play("Reload");
        shootSound.clip = reload;
        shootSound.Play();
        //aimAction.Disable();
        shootAction.Disable();
        reloadAction.Disable();
        isReloading = true;
        yield return new WaitForSeconds(time);
        isReloading = false;
        shootSound.clip = shoot;
        reloadAction.Enable();
        if (aimAction.phase.ToString() == "Started"){
            shootAction.Enable();
        }
        //aimAction.Enable();
    }

    IEnumerator ShootingMechanics(float timer)
    {
        if (magazine > 0)
            magazine--;

        magText.text = ("" + magazine + "|" + ammo);
        

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
                StartCoroutine("playreload", reloadTimer);
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
                StartCoroutine("playreload", reloadTimer);
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
                        magazine += ammo;
                        ammo = 0;
                    }
                }
            }
            else
            {

            }
        }
        magText.text = (""+magazine + "|" + ammo);
    }

    public void changeShootTime(float change){
        shootTimer = change;
    }

    public void changeReloadTime(float change){
        reloadTimer = change;
    }

}
