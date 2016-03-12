﻿// the PickupController component of the 'PickupSpawnPoints' GameObject
private var pickupController:PickupController;
 
function Awake()
{
    // retrieve the PickupSpawnPoints gameObject
    var pickupSpawnPoints:GameObject = gameObject.Find("PickupSpawnPoints");
     
    // and then retreive the PickupController Component of the above PickupSpawnPoints gameObject
    pickupController = pickupSpawnPoints.GetComponent("PickupController");
}
 
function OnControllerColliderHit (hit:ControllerColliderHit)
    {
        if (hit.gameObject.tag == "Pickup")
        {
            // call the Collected(...) function of the PickupController Component (script) and 
            // pass the pickup we hit as the parameter for the function
            Collected(hit.gameObject);
        }
    }

    function Collected(pickupCollected:GameObject)
        {
     
            // destroy the pickup
            Destroy(pickupCollected);


            //We can possibly add more functionality to this function, such as having it respawn items after a set amount of time
        
        }