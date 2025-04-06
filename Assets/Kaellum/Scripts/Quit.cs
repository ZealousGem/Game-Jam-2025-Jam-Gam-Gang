using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField] private GameObject Quiter;
    [SerializeField] private GameObject numChange;
    [SerializeField] private GameObject SafePanel;
    [SerializeField] private GameObject Prompt;
    public void QuitSafe()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Quiter.SetActive(false);
        SafePanel.SetActive(false);
        numChange.SetActive(false);
        Prompt.SetActive(true);
        Time.timeScale = 1;

        Debug.Log("Quit");
    }
    
}
