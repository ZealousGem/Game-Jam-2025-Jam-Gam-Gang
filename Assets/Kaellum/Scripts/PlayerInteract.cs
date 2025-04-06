using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    [SerializeField] private GameObject prompt;

    void Start()
    {
        cam = GetComponent<Camera>();
        playerUI = GetComponent<PlayerUI>();
    }

   
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        RayCasting();
        //creates ray to detect colliders based on set distance
    
    }
    
    void KeyInteract(Interactable interactable,RaycastHit hit)
    {

        interactable = hit.collider.GetComponent<Interactable>();
        
        playerUI.UpdateText(interactable.promptmessage);

        //Debug.Log("Interactable");
        if (Input.GetKeyDown(KeyCode.E))
        {
            prompt.SetActive(false);
            //switch case based off different interactables
            interactable.BaseInteract();
        }

    }
    void RayCasting()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo; //variable for collision info
        if (Physics.Raycast(ray, out hitInfo, distance, mask) && (hitInfo.collider.GetComponent<Interactable>() != null))
        {
            //if ray makes contact with an interactable with certain tag it will activate


            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

            KeyInteract(interactable, hitInfo);


        }
    }
    /*
    void GetInteractable(Interactable interactable, RaycastHit hit)
    {
        interactable = hit.collider.GetComponent<Interactable>();
    }
    */
    /*
    void RayCasting(Ray ray)
    {
        hitInfo = new RaycastHit();
        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            //if ray makes contact with an interactable with certain tag it will activate
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                KeyInteract(interactable, hit);
            }

        }

    }
    */
}

