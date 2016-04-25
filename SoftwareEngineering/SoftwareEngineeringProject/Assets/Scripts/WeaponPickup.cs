using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{

    public GameObject AK;
    public GameObject gun2;
    public GameObject DummyAK;
    float x;
    float z;
    public  int gunCount;
    // Use this for initialization
    void Start()
    {
        AK.SetActive(false);
        gun2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "AK")
        {
            gunCount++;
            Destroy(other.gameObject);
            if (gunCount == 2)
            {
                gun2.SetActive(false);
                AK.SetActive(true);

            }
            else
            {
                AK.SetActive(true);
            }

        }//end if

        if(other.tag == "AKBlank")
        {
            gunCount++;
            Destroy(other.gameObject);
            if (gunCount == 2)
            {
                AK.SetActive(false);
                gun2.SetActive(true);
            }
            else
            {
                gun2.SetActive(true);
            }
            
        }//end if
    }

    void FixedUpdate()
    {
        

        if(gunCount == 2)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))//Weapon Switch Mouse1 == Right Mouse Click
            {
                if (gun2.activeSelf)
                {
                    gun2.SetActive(false);
                    AK.SetActive(true);
                }
                else
                {
                    if (AK.activeSelf)
                    {
                        AK.SetActive(false);
                        gun2.SetActive(true);
                    }
                }
            }
        }//end if
    }//end update
}