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

    private Ray ray;
    private RaycastHit hitInfo;

    public CharacterControl player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if (!interactables.Contains(other.gameObject))
        {
            if (other.GetComponent<ItemWorld>()){
                interactables.Add(other.gameObject);
                interactables[0].gameObject.GetComponentInChildren<Renderer>().materials[0].color = Color.red;
            }
            Debug.Log("Entra "+other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (interactables.Contains(other.gameObject))
        {
            if (other.GetComponent<ItemWorld>()){
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
        }
    }
}
