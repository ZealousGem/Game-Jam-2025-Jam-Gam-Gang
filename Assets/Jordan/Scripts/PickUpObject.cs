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
        picked = false;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (picked)
            {
                DropObject();
            }

            else
            {
                Camera cam = Camera.main;
                Ray ray = new Ray(cam.transform.position, cam.transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10f))
                {

                    if (hit.transform == transform)
                    {
                        PickupObject();
                        Debug.Log("picked up");
                    }
                }
                else
                {
                    Debug.Log("nothing");
                }
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !picked && !other.CompareTag("PickedUp"))
        {
            playerAround = true;
        }

       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !picked && !other.CompareTag("PickedUp"))
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
        Collider col = GetComponent<Collider>();
        if(rb != null){
            rb.isKinematic = true;
            transform.localPosition = new Vector3(0, 0, 1);
        }

        if (col != null)
        {
            col.enabled = false;
        }
       
    }

    void DropObject()
    {
        transform.SetParent(null);
        picked = false;
        holdingItem = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        Collider col = GetComponent<Collider>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        if (col != null)
        {
            col.enabled = true;
        }

        transform.position = transform.position;
    }

}
