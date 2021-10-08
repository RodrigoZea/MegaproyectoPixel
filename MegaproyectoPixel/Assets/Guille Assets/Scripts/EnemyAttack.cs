using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float recovery = 3.0f;
    [SerializeField]
    private float damage = -0.1f;
    private bool attackAvailable = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other) {
        if (attackAvailable){
            if (other.gameObject.tag == "Player"){
                GameManager.Instance.updateHealth(damage);
                StartCoroutine("recover", recovery);
                other.gameObject.GetComponent<CharacterControl>().HitReaction();
                attackAvailable = false;
            }
        }
    }

    IEnumerator recover(float timer)
    {
        yield return new WaitForSeconds(timer);
        attackAvailable = true;
    }
}
