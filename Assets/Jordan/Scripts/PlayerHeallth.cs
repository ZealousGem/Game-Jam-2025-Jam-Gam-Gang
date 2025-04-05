using System.Collections;
using UnityEngine;

public class PlayerHeallth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PlayerHeallth instance;

    public float MaxHealth = 100f;
    public float currentHealth;
    Coroutine regenCor;

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

    private void Update()
    {
        //  Debug.Log(currentHealth);
        StartCoroutine(RegenHealth(1f));
    }

    public void Health()
    {

    }
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float dam)
    {
        currentHealth -= dam * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
         //   Time.timeScale = 0f;
            StopCoroutine(regenCor);
        }

       
        regenCor = StartCoroutine(RegenHealth(1f));
    }

    public IEnumerator RegenHealth(float health)
    {
        yield return new WaitForSeconds(2f);
        currentHealth += health * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
    }
}
