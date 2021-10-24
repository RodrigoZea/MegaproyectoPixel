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
    public float lookradius = 10f;
    public Transform player;
    public float attackradius = 2f;

    public GameObject attackArea;

    public float health;

    public CharacterControl playerController;

    private float damage;

    [SerializeField]
    private List<GameObject> puntos;

    public enemyType EnemyType;
    private Animator animator;
    private CapsuleCollider capsule;
    private float waitTimer = 1f;

    //Patroling
    private int currentPoint = 0;
    public Vector3 walkpoint;
    bool walkPointSet;

    //Attacking
    public float timeBetweenAttacks;
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

            float distanceToPlayer = Vector3.Distance(player.position, transform.position);
            
            if(distanceToPlayer >= lookradius)
            {
                Patroling();
            }
            else
            {
                FollowPlayer();
            }

        }

        if(health <= 0)
        {
            //DestroyEnemy();
            attackArea.SetActive(false);            
            dead = true;
            animator.enabled = false;
            agent.enabled = false;
            capsule.enabled = false;            
        }
    }

    private void avoidWalls()
    {
        //Ray raycast;
        //RaycastHit hit;
        //raycast.origin = attackArea.transform.position;
        //raycast.direction = attackArea.transform.position;
        //if (Physics.Raycast(raycast, out hit))
        //{
        //
        //}
    }

    private void Patroling()
    {
        //animator.applyRootMotion = true;
        agent.speed = 1f;
        agent.acceleration = 1f;
        animator.SetBool("Running", false);
        animator.SetBool("Walking", true);
        //animator.SetBool("IDLE", false);

        if (!walkPointSet) SearchWalkPoint();
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= lookradius)
        {
            if (distanceToPlayer <= agent.stoppingDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
            }
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkpoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            StartCoroutine("waitInPosition", waitTimer);
        }
    }

    IEnumerator waitInPosition(float time)
    {
        //animator.SetBool("IDLE", true);
        //animator.SetBool("Walking", false);
        //animator.SetBool("Running", false);
        walkPointSet = true;
        yield return new WaitForSeconds(time);
        walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        if (puntos.Count > 0)
        {
            List<GameObject> SeleccionPuntos = new List<GameObject>();

            for (int i = 0; i < puntos.Count; i++)
            {
                if (i != currentPoint)
                {
                    SeleccionPuntos.Add(puntos[i]);
                }
            }

            int newPoint = Random.Range(0, SeleccionPuntos.Count);
            int selectedPoint = puntos.IndexOf(SeleccionPuntos[newPoint]);
            Debug.Log(puntos[currentPoint].transform.position);
            Debug.Log(SeleccionPuntos[newPoint].transform.position);
            currentPoint = selectedPoint;
            walkpoint = new Vector3(SeleccionPuntos[newPoint].transform.position.x, 0, puntos[newPoint].transform.position.z);
        }
        else
        {
            //Se quedaria en el mismo lugar
            walkpoint = new Vector3(agent.transform.position.x, 0, agent.transform.position.z);
        }

        walkPointSet = true;

        agent.SetDestination(walkpoint);
    }

    private void FollowPlayer()
    {
        animator.SetBool("Running", true);
        animator.SetBool("Walking", false);
        //animator.SetBool("IDLE", false);
        agent.speed = 2f;
        agent.acceleration = 2f;
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookradius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackradius);
    }

}
