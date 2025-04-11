using UnityEngine;

public class CardDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Collider Door;
    public GameObject doorUI;
    bool moving;
    public Vector3 moveDoor;
    public Vector3 OriginalSpot;
    

    void Start()
    {
        moving = false;
        doorUI.SetActive(false);
    }

    private void Update()
    {
        if (moving)
        {
         DoorAnimation(moveDoor);
        }

        else
        {
          DoorAnimation(OriginalSpot);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (this.gameObject.tag == "Door1" && PlayerKeyCards.Instance.hasKeycard1 == true)
            {
                try { AudioManager.Instance.PlaySound("door"); } catch { }
                Door.enabled = false;
                moving = true;  
            }

            else if(this.gameObject.tag == "Door2" && PlayerKeyCards.Instance.hasKeycard2 == true)
            {
                try { AudioManager.Instance.PlaySound("door"); } catch { }
                Door.enabled = false;
                moving = true;
            }

           else if(this.gameObject.tag == "Door3" && PlayerKeyCards.Instance.hasKeycard3 == true)
            {
                try { AudioManager.Instance.PlaySound("door"); } catch { }
                Door.enabled = false;
                moving = true;
            }

            else
            {
                try { AudioManager.Instance.PlaySound("UiSound"); } catch { }
                doorUI.SetActive(true);
            }
        }
       
    }

    void DoorAnimation(Vector3 moving)
    {
        if (transform.position != moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, moving, 15f * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorUI.SetActive(false);
            moving = false;
        }
    }
}
