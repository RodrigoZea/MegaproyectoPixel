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
            interactables.Add(other.gameObject);
            Debug.Log("Entra "+other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (interactables.Contains(other.gameObject))
        {
            interactables.Remove(other.gameObject);
            Debug.Log("Sale "+other.gameObject.name);
        }
        
    }

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
}
