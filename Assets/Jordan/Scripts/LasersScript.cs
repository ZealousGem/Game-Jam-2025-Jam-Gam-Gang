using UnityEngine;

public class LasersScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float timer;
    float killTimer;
    GameObject Lasers;
    bool isOn;
    void Start()
    {
        Lasers = GameObject.FindGameObjectWithTag("Finish");
        //killTimer = 10f;
        Lasers.SetActive(false);
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            killTimer += Time.deltaTime;
        }

        else
        {
            timer += Time.deltaTime;
        }
       
        
        Debug.Log(timer);
        Debug.Log(killTimer);

        if (timer >= 10f)
        {
            Lasers.SetActive(true);
            isOn=true;
            killTimer = 0f;

        }

        if (killTimer >= 10f)
        {
            Lasers.SetActive(false);
            isOn=false;
            timer = 0f;
           
            

        }
    }
}
