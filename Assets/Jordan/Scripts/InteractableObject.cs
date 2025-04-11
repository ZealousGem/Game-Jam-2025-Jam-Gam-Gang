using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject UI;
    public UnityEvent Interact;
    bool Playerishere;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Playerishere)
        {
            Interact.Invoke();

        }
    }

    private void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try { AudioManager.Instance.PlaySound("UiSound"); } catch { }
            UI.SetActive(true);
            Playerishere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI.SetActive(false);
            Playerishere = false;
        }
    }

    public void TurnonExplosion()
    {
        Debug.Log("boom");
        ExplosionTimer.Instance.beginTime = true;
    }

    public void TakePowerCore()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        try { AudioManager.Instance.PlaySound("explode"); } catch { }
        try { AudioManager.Instance.StopMusic("station"); } catch { }
        SceneManager.LoadScene("EndingDialogue");
        Debug.Log("good ending");
    }
}
