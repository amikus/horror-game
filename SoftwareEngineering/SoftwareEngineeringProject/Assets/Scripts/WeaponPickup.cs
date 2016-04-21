using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{

    public GameObject AK;
    public GameObject DummyAK;
    public Collider AkColl;
    // Use this for initialization
    void Start()
    {
        AkColl = GetComponent<Collider>();
        DummyAK = GetComponent<GameObject>();
        AK.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "AK")
        {

            Destroy(other.gameObject);
            AK.SetActive(true);
        }
    }


}