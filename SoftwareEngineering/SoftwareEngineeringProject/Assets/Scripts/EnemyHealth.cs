﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /*
    DECLARE VARIABLES
    */

    //enemy health
    public int startingHealth = 100;            
    public int currentHealth;

    //points (for game type 2)
    //public int scoreValue = 10;

    //Audio clip of death, if needed
    public AudioClip deathClip;

    //references to various Unity components
    Animator anim;
    AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;

    //death state
    bool isDead;

    void Awake()
    {
        // Set up the references 
        anim = GetComponent<Animator>()                ;
        enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        // Set the current health when the enemy first spawns
        currentHealth = startingHealth;
    }

    void Update()
    {

    }


    public void TakeDamage(int amount)
    //If we decide to have particle, may need hit location,
    //and signature will change to:
    //public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // If the enemy is dead, exit function
        if (isDead)
            return;

        // Play the hurt sound effect.
        enemyAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // Set the position of the particle system to where the hit was sustained.
        //hitParticles.transform.position = hitPoint;

        // And play the particles.
        //hitParticles.Play();

        // Enemy dies if health goes to 0
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        // The enemy is dead
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it
        //capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead
        anim.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing)
        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        // Find and disable the nav mesh agent
        GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy)
        GetComponent<Rigidbody>().isKinematic = true;

        // Increase the score by the enemy's score value
        // ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 5f);

    }

}