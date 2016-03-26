using UnityEngine;
using System.Collections;
using PH;
public class KillTester : MonoBehaviour {

    PlayerHealth test;
	// Use this for initialization
	void Start () {
	
	}

    void onTriggerEnter()
    {
        test.TakeDamage(50);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
