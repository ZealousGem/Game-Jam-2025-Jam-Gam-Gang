using UnityEngine;

public class ElectricFloor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
