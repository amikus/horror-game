using UnityEngine;
using System.Collections;

public class AISimple : MonoBehaviour {

    float distance;

    //basic variables related to creature's ability to see, attack, and move
    public float lookAtDistance = 25f;
    public float attackRange = 15f;
    float moveSpeed = 5f;

    // variable for smoothing animations
    float damping = 6f;

    // get access to in game objects
    public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(target.position, transform.position);

        // if enemy can see Player
        if (distance < lookAtDistance)
        {
            //turn him yellow and have him turn towards player
            lookAt();
        }

        // if enemy cannot see Player
        if (distance > lookAtDistance)
        {

        }

        // if enemy is close enough to attack
        if (distance < attackRange)
        {
            attack();
        }

	} // Update

    void lookAt()
    {
        // gets difference between enemy's rotation and player's
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

        // enemy will slowly turn from current rotation position to face player
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

    } // lookAt

    void attack()
    {
        // enemy will close on player
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    } // attack

}
