using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Animator animator;
    public string key {get;} 
    // Start is called before the first frame update

    public void OnInteract(string condition){
        isOpen = !isOpen;
        if (isOpen){
            animator.SetBool("isOpen", true);
        } else {
            animator.SetBool("isOpen", false);

        }
    }
}
