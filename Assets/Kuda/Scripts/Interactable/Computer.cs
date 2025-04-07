using UnityEngine;

public class Computer : Interactable
{
    public GameObject compPanel;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        compPanel.SetActive(false);
    }

    protected override void Interact()
    {
        compPanel.SetActive(true);
    }
    public void ClosePaneal()
    {
        compPanel.SetActive(false);
    }


}
