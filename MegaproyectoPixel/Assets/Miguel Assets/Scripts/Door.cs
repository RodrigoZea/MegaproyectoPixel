using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool isOpen = false;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Animator animator;
    public string key {get;}
    public bool locked;
    [SerializeField]
    private AudioClip openClip;
    [SerializeField]
    private AudioClip closeClip;
    private AudioSource source;
    // Start is called before the first frame update
    private void Start() {
        locked = true;
        source = GetComponent<AudioSource>();
    }

    public void OnInteract(string condition){
        if (!locked){
            isOpen = !isOpen;
            if (isOpen){
                animator.SetBool("isOpen", true);
                source.clip = openClip;
                source.Play();
            } else {
                animator.SetBool("isOpen", false);
                source.clip = closeClip;
                source.Play();

            }
        }
    }
}
