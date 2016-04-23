using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    private PickupController pickupController;
    private Image keyImage;

    void Awake ()
    {
        
        //retrieve the PickupSpawnPoints GameObject
        GameObject pickupSpawnPoints = GameObject.Find("KeySpawnPoints");

        //and then retrieve the PickupController Component of the above PickupSpawnPoints GameObject 
        pickupController = pickupSpawnPoints.GetComponent("PickupController") as PickupController;

        //load key image for later
        GameObject keyUI = GameObject.Find("KeyUI");
        keyImage = keyUI.GetComponent<Image>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Pickup")
        {
            //call the Collected(...) function of the PickupController Component (script) and
            //pass the pickup we hit as the parameter for the function
            GameVariables.keyCollected = true;
            keyImage.enabled = true;

            //this is messing up and is causing game to end with null reference exception
            pickupController.Collected(hit.gameObject);

        }

        if (hit.gameObject.tag == "Door" && GameVariables.keyCollected == true)
        {
            Destroy(hit.gameObject);
            Application.LoadLevel("Victory");
        }
    }
}


