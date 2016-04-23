using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {


    // pickup prefab, assigned via Inspector
    public GameObject pickupPrefab;

    // number of pickups and spawnpoints in level
    public int numberOfPickups = 1;
    private int numberOfSpawnPoints;

    // array of spawnpoints that our pickup will be spawned at
    private GameObject[] spawnPointList;

    // array of which spawn points are currently available for spawning at
    private bool[] spawnIndexAvailableList = new bool[12];


    void Awake ()
    {
        
        //retrieve GameObjects tagged as 'SpawnPoint' within the 'PickupSpawnPoints' GameObject which this script is a Component of
        spawnPointList = GameObject.FindGameObjectsWithTag("SpawnPoint");

        //retrieve number of spawn points
        numberOfSpawnPoints = spawnPointList.Length;
        
        //make sure number of pickups doesn't exceed number of spawn points
        if (numberOfPickups > numberOfSpawnPoints) {
            numberOfPickups = numberOfSpawnPoints;
        }
        
        // make all spawn points available by setting each index to true
        for (int i = 0; i < numberOfSpawnPoints; i++)
        {
            
            spawnIndexAvailableList[i] = true;
            
        }
        
        // spawn X amount of pickups according to numberOfPickups
        for (int j = 0; j < numberOfPickups; j++) 
        {
            SpawnPickup();
        }
    }

    public void SpawnPickup()
    {
        // generate a random integer to use as the index to select a spawn point from the list
        int randomSpawnIndex = Random.Range(0, numberOfSpawnPoints);

        // while the selected spawn index is unavailable regenerate another one
        while (!spawnIndexAvailableList[randomSpawnIndex])
        {
            randomSpawnIndex = Random.Range(0, numberOfSpawnPoints);
        }

        // retrieve the position and rotation of the pickups spawn point
        Vector3 spawnedPickupPosition = spawnPointList[randomSpawnIndex].transform.position;
        Quaternion spawnedPickupRotation = spawnPointList[randomSpawnIndex].transform.rotation;
        spawnedPickupPosition = GameObject.Find("CenterTestSpawn").transform.position;
        // instantiate (create) the pickup prefab with the above position and rotation
        GameObject spawnedPickup = Instantiate(pickupPrefab, spawnedPickupPosition, spawnedPickupRotation) as GameObject;

        // set the spawned pickup as a child of the 'PickupSpawnPoints' gameobject that this script is a Component of
        // this is so we can use SendMessageUpwards within scripts attached to the pickupPrefab to call functions within this script
        spawnedPickup.transform.parent = spawnPointList[randomSpawnIndex].transform;

        // set the name of the pickup as its index
        spawnedPickup.name = randomSpawnIndex.ToString();

        // make the spawn index unavailable to prevent another pickup being spawned in this position
        spawnIndexAvailableList[randomSpawnIndex] = false;
    }

    public void Collected(GameObject pickupCollected)
    {
        // retrieve name of the collected pickup and cast to int
        int index = int.Parse(pickupCollected.name);

        // pickup has been destroyed so make the spawn index available again
        spawnIndexAvailableList[index] = true;

        // destroy the pickup
        Destroy(pickupCollected);

        //respawn new pickup
        //SpawnPickup();

        //We can possibly add more functionality to this function, such as having it respawn items after a set amount of time

    }
}
