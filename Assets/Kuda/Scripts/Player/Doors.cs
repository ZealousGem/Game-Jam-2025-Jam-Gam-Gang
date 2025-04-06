using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool isOpen = false;
    public PlayerKeyCards playerKeyCards;
    Collider DoorColl;

    private void Start()
    {
        DoorColl = GetComponent<Collider>();
       
    }
    private void OnCollisionEnter(Collision other)
    {
        if (this.gameObject.tag == "Door1")
        {
            if ((other.gameObject.CompareTag("Player")) && playerKeyCards.hasKeycard1 == true)
            {
                DoorColl.isTrigger = true;
            }
            else
            {
                DoorColl.isTrigger = false;
            }
        }

        if (this.gameObject.tag == "Door2")
        {
            if ((other.gameObject.CompareTag("Player")) & playerKeyCards.hasKeycard2 == true)
            {
                DoorColl.isTrigger = true;
            }
            else
            {
                DoorColl.isTrigger = false;
            }
        }

        if (this.gameObject.tag == "Door3")
        {
            if ((other.gameObject.CompareTag("Player")) & playerKeyCards.hasKeycard3 == true)
            {
                DoorColl.isTrigger = true;
            }
            else
            {
                DoorColl.isTrigger = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "Door1")
        {
            if ((other.gameObject.CompareTag("Player")) && playerKeyCards.hasKeycard1 == true)
            {
                DoorColl.isTrigger = false;
            }
            
        }

        if (this.gameObject.tag == "Door2")
        {
            if ((other.gameObject.CompareTag("Player")) & playerKeyCards.hasKeycard2 == true)
            {
                DoorColl.isTrigger = false;
            }
        }

        if (this.gameObject.tag == "Door3")
        {
            if ((other.gameObject.CompareTag("Player")) & playerKeyCards.hasKeycard3 == true)
            {
                DoorColl.isTrigger = false;
            }
        }
    }

}
