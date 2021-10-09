using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{
    public List<GameObject> interactables = new List<GameObject>();
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
                        //currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                        currentHighlight.GetComponentInChildren<Outline>().enabled = false;
                    }
                    currentHighlight = highlightInfo.collider.gameObject;
                    //currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
                    currentHighlight.GetComponentInChildren<Outline>().enabled = true;
                } else {
                    if (currentHighlight != null){
                        //currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                        currentHighlight.GetComponentInChildren<Outline>().enabled = false;
                        currentHighlight = null;
                    }
                }
            } else {
                if (currentHighlight != null){
                        //currentHighlight.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                        currentHighlight.GetComponentInChildren<Outline>().enabled = false;
                        currentHighlight = null;
                    }
            }
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (!interactables.Contains(other.gameObject))
        {
            if (other.GetComponent<ItemWorld>() || other.GetComponent<IInteractable>() != null){
                if(other.GetComponent<Door>() != null)
                {
                    
                }
                interactables.Add(other.gameObject);
                //interactables[0].gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
                interactables[0].gameObject.GetComponentInChildren<Outline>().enabled = true;
            }
            //Debug.Log("Entra "+other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (interactables.Contains(other.gameObject))
        {
            if (other.GetComponent<ItemWorld>() || other.GetComponent<IInteractable>() != null){
                //other.gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.white;
                other.gameObject.GetComponentInChildren<Outline>().enabled = false;
                interactables.Remove(other.gameObject);
                if (interactables.Count > 0)
                    //interactables[0].gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
                    interactables[0].gameObject.GetComponentInChildren<Outline>().enabled = true;
            }
            //Debug.Log("Sale "+other.gameObject.name);
        }
        
    }

    public virtual void Interact(){
        if (interactables.Count > 0){
            if (interactables[0].GetComponent<ItemWorld>() != null)
                {
                    GameObject temp = interactables[0];
                    ItemWorld itemWorld = temp.GetComponent<ItemWorld>();
                    Item item = itemWorld.GetItem();
                    bool waspickedup = player.inventory.addItem(item);
                    if (waspickedup)
                    {

                    }
                    temp.gameObject.SetActive(false);
                    interactables.Remove(temp.gameObject);
                    if (interactables.Count > 0)
                        //interactables[0].gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
                        interactables[0].gameObject.GetComponentInChildren<Outline>().enabled = true;
                    Destroy(temp);
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
