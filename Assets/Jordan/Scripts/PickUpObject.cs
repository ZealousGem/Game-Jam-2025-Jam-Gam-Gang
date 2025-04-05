using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    GameObject Player;
    static bool holdingItem = false;
    bool picked;
    bool playerAround;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAround)
        {
            if (Input.GetKeyDown(KeyCode.E) && !picked)
            {
                PickupObject();
            }

            else if(picked && Input.GetKeyDown(KeyCode.E))
            {
                DropObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !picked && !other.CompareTag("PickedUp"))
        {
            playerAround = true;
        }

        else
        {
            playerAround = false;
        }
    }

    void PickupObject()
    {
        if (holdingItem) return;
        transform.SetParent(Player.transform);
        picked = true;
        holdingItem = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null){
            rb.isKinematic = true;
            transform.localPosition = new Vector3(0, 0, 1);
        }
       
    }

    void DropObject()
    {
        transform.SetParent(null);
        picked = false;
        holdingItem = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        transform.position = transform.position;
    }

}
