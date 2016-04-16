using UnityEngine;
using System.Collections;
using PH;

public class EnemyAttack : MonoBehaviour
{
    //set up basic attack variables
    public float timeBetweenAttacks = 5.0f;
    public int attackDamage = 25;

    //reference to animator component
    Animator anim;

    //references to player object
    GameObject player;
    PlayerHealth playerHealth;

    //reference to enemy's health
    EnemyHealth enemyHealth;
   
    //is player in range to be hit?
    bool playerInRange;
    //has enough time passed to attack again?
    float timer = 9;


    void Awake()
    {
        // Set up the references to Unity components
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
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


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks and player is in range and enemy is alive, attack
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        // If the player is dead, don't attack
        if (playerHealth.currentHealth <= 0)
        {
            //unsure if we'll want to put anything here
            //anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        anim.Play("Attack1");

        // If the player has health to lose, damage the player
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}