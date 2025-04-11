using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject minigame;
    public GameObject pcUI;
    
   
    private void Start()
    {
        //desktopScreen.SetActive(true);
        minigame.SetActive(false);
        pcUI.SetActive(false);
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

                Camera cam = Camera.main;
                Ray ray = new Ray(cam.transform.position, cam.transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 10f) )
                {
                  if (hit.transform == transform)
                  {
                    SelectMiniGame();
                  }
                   

                }
            
            
           

        }

       
    }

    public void SelectMiniGame()
    {
        try { AudioManager.Instance.PlaySound("pc"); } catch { }
        PlayerController Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player.enabled = false;
        minigame.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pcUI.SetActive(true);
            
        }

       
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pcUI.SetActive(false);
            
        }
    }




    public void CloseApp()
    {
        PlayerController Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Player.enabled = true;
        minigame.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
