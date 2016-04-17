using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // set up initial variables
    public PH.PlayerHealth playerHealth;
    public GameObject enemy;         
    public float spawnTime = 3f;     

    //could have multiple spawn points if I want, but in this case will only be using one
    public Transform[] spawnPoints;  


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // If player has no health, don't spawn anything
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        // Find a random index between zero and one less than the number of spawn points
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy at the randomly selected spawn point's position and rotation
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}