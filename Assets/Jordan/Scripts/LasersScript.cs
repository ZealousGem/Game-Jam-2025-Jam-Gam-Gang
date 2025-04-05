using UnityEngine;

public class LasersScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float timer;
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
            timer += Time.deltaTime;
        }

        else
        {
            timer += Time.deltaTime;
        }
       
        
      //  Debug.Log(timer);
     

        if (timer >= 5f)
        {
           

            if (isOn)
            {
                Lasers.SetActive(false);
                isOn = false;




            }

            else
            {
                Lasers.SetActive(true);
                isOn=true;
            }

            timer = 0f;
        }

       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isOn)
        {
            Debug.Log("detecting player");
            if (PlayerHeallth.instance.currentHealth > 0)
            {
                try
                {
                    PlayerHeallth.instance.TakeDamage(30f);
                }

                catch { }
            }

            else
            {
                PlayerHeallth.instance.StopRegen();
            }
            
        }
    }

   
}
