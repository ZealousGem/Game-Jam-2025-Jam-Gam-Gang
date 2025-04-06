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

    void Start()
    {
        cam = GetComponent<Camera>();
        playerUI = GetComponent<PlayerUI>();
    }


    void Update()
    {
        playerUI.UpdateText(string.Empty);

        //creates ray to detect colliders based on set distance

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo; //variable for collision info
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            //if ray makes contact with an interactable with certain tag it will activate
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptmessage);

                //Debug.Log("Interactable");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //switch case based off different interactables
                    interactable.BaseInteract();
                }
            }

        }
    }
}