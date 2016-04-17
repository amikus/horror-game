using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{
    
    //variables related to movement/orientation
    float distance;
    //float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    public float lookAtDistance = 25f;
    public float chaseRange = 15f;
    float moveSpeed = 3f;
    // Reference to the nav mesh agent.
    NavMeshAgent nav;
    // for controlling how far enemy can roam
    Vector3 startPosition;
    public int roamRadius = 100;

    // variables related to attacking
    public float attackRange = 1.5f;
    public float timeBetweenAttacks = .2f;
    public int attackDamage = 25;
    //is player in range to be hit?
    bool playerInRange;
    //has enough time passed to attack again?
    float timer = 9;

    // variable for smoothing animations
    float damping = 6f;

    // get access to in game objects
    Transform target;
    Animator anim;
    //references to player object
    GameObject player;
    PH.PlayerHealth playerHealth;
    //reference to enemy
    EnemyHealth enemyHealth;

    void Awake()
    {
        // Set up the references to Unity components
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PH.PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        target = player.transform;
        nav = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    // Use this for initialization
    void Start()
    {

    }

    // If player enters collider range, player is in range to attack
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    // If player exits collider range, player is out of range to attack
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        if (nav.enabled)
        {
            //get distance between enemy and player
            distance = Vector3.Distance(target.position, transform.position);

            // If the timer exceeds the time between attacks and player is in range and enemy is alive, attack
            if (distance < attackRange && timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                anim.SetTrigger("Walk");
                attack();
            }
            // if enemy is close enough to chase
            else if (distance < chaseRange && distance >= attackRange)
            {
                anim.SetTrigger("Walk");
                chase();

            }
            else if (distance < lookAtDistance)
            {
                anim.SetTrigger("Walk");
                lookAt();
            } else if   (distance > lookAtDistance)
            {
                anim.SetTrigger("Walk");
                wander();
            }

        }
    } // Update

    void lookAt()
    {
        // gets difference between enemy's rotation and player's
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

        // enemy will slowly turn from current rotation position to face player
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

    } // lookAt


    void chase()
    {
       
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(target.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }

    } // chase

    void attack()
    {
        // Reset the timer.
        timer = 0f;

        anim.Play("Attack1");

        // If the player has health to lose, damage the player
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    } // attack

    void wander()
    {
        //generate a vector that's a random distance away from starting position
        Vector3 waypoint = Random.insideUnitSphere * roamRadius;
        waypoint += startPosition;

        nav.SetDestination(waypoint);

    }

}
