using UnityEngine;

public class MouseSensitivity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static MouseSensitivity instance;

    public float Amount; 
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void changeAmount(float amount)
    {
        Amount = amount;
    } 
}
