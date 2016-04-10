// the PickupController component of the 'PickupSpawnPoints' GameObject
private var pickupController:PickupController;
private var keyCollected = false;
 
function Awake()
{
    // retrieve the PickupSpawnPoints gameObject
    var pickupSpawnPoints:GameObject = gameObject.Find("KeySpawnPoints");
     
    // and then retreive the PickupController Component of the above PickupSpawnPoints gameObject
    pickupController = pickupSpawnPoints.GetComponent("PickupController");
}
 
function OnControllerColliderHit (hit:ControllerColliderHit)
    {
        if (hit.gameObject.tag == "Pickup")
        {
            // call the Collected(...) function of the PickupController Component (script) and 
            // pass the pickup we hit as the parameter for the function
            keyCollected = true;
            pickupController.Collected(hit.gameObject);
        }
        if(hit.gameObject.tag == "Door" && keyCollected == true)
        {
            Destroy(hit.gameObject);
            Application.LoadLevel ("Victory");
        }
    }

