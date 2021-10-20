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
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;

    private bool dead = false;

    private void Awake()
    {
        try
        {
            player = GameObject.Find("ThirdPerson").transform;
        } catch
        {
            player = GameObject.Find("FirstPerson").transform;
        }

        playerInAttackRange = false;
        playerInsightRange = false;

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        capsule = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {

        if (!dead){
            playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInsightRange && !playerInAttackRange) Patroling();
            if (playerInsightRange && !playerInAttackRange) ChasePlayer();
            if (playerInsightRange && playerInAttackRange) AttackPlayer();
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
            agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack Code
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 32f, ForceMode.Impulse);


            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entro collision enter");
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

    private void ResetAttack()
    {
        alreadyAttacked = false;
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
