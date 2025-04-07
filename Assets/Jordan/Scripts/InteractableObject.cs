using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Playerishere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadScene("SampleScene");
        Debug.Log("good ending");
    }
}
