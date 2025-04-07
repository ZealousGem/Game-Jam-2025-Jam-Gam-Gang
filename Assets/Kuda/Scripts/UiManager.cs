using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject minigame;
   
    private void Start()
    {
        //desktopScreen.SetActive(true);
        minigame.SetActive(false);
        
    }

   public void SelectMiniGame()
    {
       
        minigame.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }



    private void OnTriggerStay(Collider other)
    {
        
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player"))
        {
            SelectMiniGame();
        }
    }

    


    public void CloseApp()
    {
        
        minigame.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

    }
}
