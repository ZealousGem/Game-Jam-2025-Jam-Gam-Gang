using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerHeallth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PlayerHeallth instance;

    public float MaxHealth = 100f;
    public float currentHealth;
    public bool isDamaged;
    Coroutine regenCor;
    Rigidbody rb;
    Collider col;

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
        
    }

    public void Health()
    {

    }
    void Start()
    {
        currentHealth = MaxHealth;
        isDamaged = false;
    }

    // Update is called once per frame
    public void TakeDamage(float dam)
    {
        currentHealth -= dam * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
        isDamaged = true;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SetDeathState(true);
         //   Time.timeScale = 0f;
           
        }

        else
        {
            
            if (regenCor != null) StopCoroutine(regenCor);
            regenCor = StartCoroutine(RegenHealth(1f, 10f));
        }

       


    }

    public void StopRegen()
    {
        StopCoroutine(regenCor);
        Debug.Log("stopping");
    }

    public void SetDeathState(bool isdead)
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        rb.isKinematic = !isdead;

        col = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
        col.enabled = isdead;

        Camera cam = Camera.main;
        if (isdead)
        {
            cam.transform.SetParent(rb.transform, false);
        }
       else
        {
            cam.transform.SetParent(null);
        }
    }


    public IEnumerator RegenHealth(float health, float delay)
    {
        if (currentHealth <= 0)
        {
            yield break;
        }
        yield return new WaitForSeconds(delay);
        //   yield return new WaitForSeconds(2f * Time.deltaTime);
        while (currentHealth < MaxHealth)
        {
            currentHealth += health * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
            yield return null;
        }

        regenCor = null;
        
    }
}
