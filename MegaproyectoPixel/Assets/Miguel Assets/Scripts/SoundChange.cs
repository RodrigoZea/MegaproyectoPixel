using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource sound;

    public void StopSound(){
        if (sound.isPlaying){
            sound.Stop();
        }
    }

    public void SetSound(float no){
        if(! sound.isPlaying){
            sound.Play();
        }

        sound.volume = no;


    }
}
