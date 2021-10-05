using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{
    private List<GameObject> interactables = new List<GameObject>();
    [SerializeField]
    private Transform raycastOrigin;
    [SerializeField]
    private Transform raycastDestiny;
    public bool raycast;
    private Ray ray;
    private RaycastHit hitInfo;

    public CharacterControl player;
    private Ray rayHighlight;
    private RaycastHit highlightInfo;
    private GameObject currentHighlight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (raycast){
            rayHighlight.origin = raycastOrigin.position;
            rayHighlight.direction = raycastDestiny.position - raycastOrigin.position;
            if (Physics.Raycast(rayHighlight, out highlightInfo, 3.0f)){
                Debug.DrawLine(rayHighlight.origin, highlightInfo.point, Color.blue, 2.0f);
                if (highlightInfo.collider.gameObject.GetComponent<ItemWorld>() != null){
                    if (currentHighlight != null){
                        currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                    }
                    currentHighlight = highlightInfo.collider.gameObject;
                    currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
                } else {
                    if (currentHighlight != null){
                        currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                        currentHighlight = null;
                    }
                }
            } else {
                if (currentHighlight != null){
                        currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                        currentHighlight = null;
                    }
            }
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (!interactables.Contains(other.gameObject))
        {
            if (other.GetComponent<ItemWorld>() || other.GetComponent<IInteractable>() != null){
                interactables.Add(other.gameObject);
                interactables[0].gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
            }
            Debug.Log("Entra "+other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (interactables.Contains(other.gameObject))
        {
            if (other.GetComponent<ItemWorld>() || other.GetComponent<IInteractable>() != null){
                other.gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                interactables.Remove(other.gameObject);
                if (interactables.Count > 0)
                    interactables[0].gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
            }
            Debug.Log("Sale "+other.gameObject.name);
        }
        
    }


    /*
    public void Interact(){
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestiny.position - raycastOrigin.position;
        if(Physics.Raycast(ray, out hitInfo)){
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
            Debug.Log("Hit"+hitInfo.collider.gameObject.name);
            float distance = Vector3.Distance(hitInfo.transform.position, raycastOrigin.transform.position);

            foreach (GameObject x in interactables){
                Debug.Log("-"+x.name);
            }
            if (interactables.Contains(hitInfo.collider.gameObject))
            {
                IInteractable interS = hitInfo.collider.GetComponent<IInteractable>();
                if (interS != null){
                    interS.OnInteract("hello");
                    Debug.Log("Run interact");                    
                }
            }
            if (hitInfo.collider.GetComponent<ItemWorld>() != null)
            {
                ItemWorld itemWorld = hitInfo.collider.GetComponent<ItemWorld>();
                Item item = itemWorld.GetItem();
                player.inventory.AddItem(item);
                //interactables.Remove(hitInfo.transform.gameObject);
                //interactables.Remove(hitInfo.collider.gameObject);
                //Destroy(hitInfo.collider.gameObject);
                Debug.Log("I AM HERE");
                hitInfo.collider.enabled = false;
                hitInfo.transform.gameObject.SetActive(false);
            }
        }
    }
    */
    public void Interact(){
        if (raycast){
            ray.origin = raycastOrigin.position;
            ray.direction = raycastDestiny.position - raycastOrigin.position;
            if(Physics.Raycast(ray, out hitInfo, 2.0f)){
                Debug.DrawLine(ray.origin, hitInfo.point, Color.blue, 2.0f);
                if(hitInfo.collider.gameObject.GetComponent<ItemWorld>() != null)
                {
                    GameObject temp = hitInfo.collider.gameObject;
                    ItemWorld itemWorld = temp.GetComponent<ItemWorld>();
                    Item item = itemWorld.GetItem();
                    bool waspickedup = player.newInventory.addItem(item);
                    player.inventory.AddItem(item);
                    temp.gameObject.SetActive(false);
                    interactables.Remove(temp.gameObject);
                    if (waspickedup) 
                        Destroy(temp);
                }
            }
        }
        if (interactables.Count > 0){
            if (interactables[0].GetComponent<ItemWorld>() != null)
                {
                    GameObject temp = interactables[0];
                    ItemWorld itemWorld = temp.GetComponent<ItemWorld>();
                    Item item = itemWorld.GetItem();
                    player.inventory.AddItem(item);
                    //interactables.Remove(hitInfo.transform.gameObject);
                    //interactables.Remove(hitInfo.collider.gameObject);
                    //Destroy(hitInfo.collider.gameObject);
                    Debug.Log("I AM HERE");
                    temp.gameObject.SetActive(false);
                    interactables.Remove(temp.gameObject);
                    if (interactables.Count > 0)
                        interactables[0].gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
                    Destroy(temp);

                    //hitInfo.transform.gameObject.SetActive(false);
                }
            else
            if (interactables[0].GetComponent<IInteractable>() != null)
                {
                    GameObject temp = interactables[0];
                    IInteractable interactable = temp.GetComponent<IInteractable>();
                    interactable.OnInteract("hola");
                }
        }
    }
}
