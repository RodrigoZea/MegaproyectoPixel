using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        shootAction = playerInput.actions["Shoot"];
        shootAction.performed += _ => Shoot();
        //shootAction.canceled

        reloadAction = playerInput.actions["Reload"];
        reloadAction.performed += _ => Reload();
        //shootAction.canceled += _ => ;

        //inventory = GetComponent<Inventory>();
        /*
        ammo = Inventory.instance.inventory[gunIndex].ammo;
        magazine = Inventory.instance.inventory[gunIndex].magazine;
        shootTimer = Inventory.instance.inventory[gunIndex].shootTimer;
        shootSound = Inventory.instance.inventory[gunIndex].shootSound;
        */
        /*if (gunGameMesh != null)
            Destroy(gunGameMesh);

        GameObject gunMesh = Instantiate(inventory.inventory[gunIndex].weaponMesh, gunHold.position, Quaternion.identity);

        gunGameMesh = gunMesh;

        animationBlend2DController = gunGameMesh.GetComponent<Animator>();
        
        shootPoint = gunMesh.transform.GetComponentInChildren<Transform>();
        */

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        //Logica de Raycast con el boton de raycast
        if (!isShooting)
        {

            StartCoroutine("ShootingMechanics", shootTimer);
            Ray ray;
            RaycastHit hit;
            if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, 100f))
            {
                //Si pega a algo
                if (hit.collider)
                {
                    GameObject hitFX = Instantiate(hit_fx, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                } 
            }
        }

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
        
        if(magazine == 0)
        {
            if(ammo > 0)
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
