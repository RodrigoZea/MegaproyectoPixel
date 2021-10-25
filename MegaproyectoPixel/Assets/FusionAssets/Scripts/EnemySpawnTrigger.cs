using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemigos;
    

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            foreach(GameObject i in enemigos){
                i.SetActive(true);
            }
        }
    }
}
