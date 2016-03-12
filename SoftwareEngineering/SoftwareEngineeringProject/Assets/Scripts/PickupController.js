// the pickup prefab, assigned via the Inspector
public var pickupPrefab:GameObject;
 
// the spawnpoint that our pickup will be spawned at
private var spawnPoint:GameObject;
 
 
function Awake()
{
    // retrieve GameObject tagged as 'SpawnPoint' within the 'PickupSpawnPoints' GameObject which this script is a Component of
    spawnPoint = gameObject.FindWithTag("SpawnPoint");
     
    // spawn the pickup
    SpawnPickup();
}
 
function SpawnPickup()
{
    // retrieve the position and rotation of the pickup's spawn point
    var spawnedPickupPosition:Vector3 = spawnPoint.transform.position;
    var spawnedPickupRotation:Quaternion = spawnPoint.transform.rotation;
     
    // instantiate (create) the pickup prefab with the above position and rotation
    var spawnedPickup:GameObject = Instantiate(pickupPrefab, spawnedPickupPosition, spawnedPickupRotation);
     
    // set the spawned pickup as a child of the 'PickupSpawnPoints' gameobject that this script is a Component of
    spawnedPickup.transform.parent = spawnPoint.transform;
}