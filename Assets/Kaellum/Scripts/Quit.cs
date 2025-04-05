using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField] private GameObject Quiter;
    [SerializeField] private GameObject numChange;
    [SerializeField] private GameObject SafePanel;
    public void QuitSafe()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Quiter.SetActive(false);
        SafePanel.SetActive(false);
        numChange.SetActive(false);

        Time.timeScale = 1;

        Debug.Log("Quit");
    }
    
}
