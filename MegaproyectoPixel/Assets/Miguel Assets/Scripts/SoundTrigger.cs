using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioSource target;
    [SerializeField]
    private bool StopOnTrigger = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Algo entro");
        if (other.tag == "Player"){
            if (StopOnTrigger){
                if (target.isPlaying){
                    target.Stop();
                }
            }else {
                if (!target.isPlaying){
                    target.Play();
                    Debug.Log("Playing audio");
            }
            }
        }
       //gameObject.SetActive(false);
    }
}
