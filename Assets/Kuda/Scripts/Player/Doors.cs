using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool isOpen = false;
    PlayerKeyCards playerKeyCards;
    Collider DoorColl;

    public SceneManagement sceneManagement;
    

    private void Start()
    {
        playerKeyCards = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerKeyCards>();
        DoorColl = GetComponent<Collider>();
       
    }
    private void OnCollisionEnter(Collision other)
    {
        if (this.gameObject.tag == "Door1")
        {
            if ((other.gameObject.CompareTag("Player")) && playerKeyCards.hasKeycard1 == true)
            {
                DoorColl.isTrigger = true;
                sceneManagement.GoToLevel2();

            }
            else
            {
                DoorColl.isTrigger = false;
                Debug.Log("No KeyCard");
            }
        }

        if (this.gameObject.tag == "Door2")
        {
            if ((other.gameObject.CompareTag("Player")) & playerKeyCards.hasKeycard2 == true)
            {
                DoorColl.isTrigger = true;
                sceneManagement.GoToLevel3();
            }
            else
            {
                DoorColl.isTrigger = false;
                Debug.Log("No KeyCard");
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
                Debug.Log("No KeyCard");
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
