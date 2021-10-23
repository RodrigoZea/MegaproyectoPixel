using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum enemyType{
    Normal, 
    Insanity
}

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject attackArea;

    public float health;

    public CharacterControl playerController;

    private float damage;

    [SerializeField]
    private List<GameObject> puntos;

    public enemyType EnemyType;
    private Animator animator;
    private CapsuleCollider capsule;

    //Patroling
    private int currentPoint = 0;
    public Vector3 walkpoint;
    bool walkPointSet;

    //Attacking
    public float timeBetweenAttacks;

    public GameObject projectile;

    //States
    public float sightRange, attackRange;

    private bool dead = false;

    private void Awake()
    {
        try
        {
            player = GameObject.Find("ThirdPerson").transform;
        } catch
        {
            player = GameObject.Find("Main Character").transform;
        }


        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        capsule = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {

        if (!dead){
            Patroling();
        }

        if(health <= 0)
        {
            //DestroyEnemy();
            dead = true;
            animator.enabled = false;
            agent.enabled = false;
            capsule.enabled = false;
            attackArea.SetActive(false);
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        
        if (walkPointSet)
        {
            agent.SetDestination(walkpoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkpoint;
        Debug.Log(distanceToWalkPoint.magnitude);
        if (distanceToWalkPoint.magnitude < 1f)
        {   
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        List<GameObject> SeleccionPuntos = new List<GameObject>();

        for (int i=0; i < puntos.Count; i++)
        {
            if (i != currentPoint)
            {
                SeleccionPuntos.Add(puntos[i]);
            }
        }

        Debug.Log(SeleccionPuntos);
        Debug.Log(currentPoint);

        int newPoint = Random.Range(0, SeleccionPuntos.Count);
        currentPoint = newPoint;

        walkpoint = new Vector3(SeleccionPuntos[newPoint].transform.position.x, 0, puntos[newPoint].transform.position.z);
        walkPointSet = true;
        Debug.Log(walkpoint);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("entro collision enter");
        if (EnemyType == enemyType.Normal)
        {
            if (collision.collider.GetComponent<CharacterControl>())
            {
                GameManager.Instance.updateHealth(damage);
            }

        } else if(EnemyType == enemyType.Insanity)
        {
            if (collision.collider.GetComponent<CharacterControl>())
            {
                GameManager.Instance.updateInsanity(damage);
            }
        }

    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        
    }

}
