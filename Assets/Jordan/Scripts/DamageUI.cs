using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Image;
    public  CanvasGroup Damage;
    //public static bool isDamage;
    void Start()
    {
       // Image = GameObject.FindGameObjectWithTag("damage");
       // Damage = Image.GetComponent<CanvasGroup>();
        Damage.alpha = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHeallth.instance.isDamaged)
        {
            StartCoroutine(FadingImage());
        }
    }

    IEnumerator FadingImage()
    {


        //  Image.SetActive(true);
        Damage.alpha = 1f;
        yield return new WaitForSeconds(2f);
        float FadeTime = 1f;
        float time = 0f;

        while (time < FadeTime)
        {
            time += Time.deltaTime;
            Damage.alpha = Mathf.Lerp(1f, 0f, time / FadeTime);
            yield return null;

        }
        PlayerHeallth.instance.isDamaged = false;
        Damage.alpha = 0f;


    }
}
