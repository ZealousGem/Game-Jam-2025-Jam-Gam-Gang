using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UIElements;




public class Safe : Interactable
{

    [SerializeField] private GameObject Quit;
    [SerializeField] private GameObject numChange;
    [SerializeField] private GameObject SafePanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Quit.SetActive(false);
        SafePanel.SetActive(false);
        numChange.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        UnhideCursor();
        // base.Interact();    
        Debug.Log("Interacted with " + gameObject.name);

        Time.timeScale = 0;

        Quit.SetActive(true);
        SafePanel.SetActive(true);
        numChange.SetActive(true);

        //GetComponent<>
        //open Unlock UI
    }
    public void UnhideCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
