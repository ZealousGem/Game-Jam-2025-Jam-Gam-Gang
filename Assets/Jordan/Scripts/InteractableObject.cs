using UnityEngine;
using UnityEngine.Events;

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
        Debug.Log("good ending");
    }
}
