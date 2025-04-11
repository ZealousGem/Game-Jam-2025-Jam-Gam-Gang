using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class KeyCardUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject objUI;
    public TMP_Text ObjText;
    public static Action OnKeyCardCollect;
    bool hasKeycard2 = false;
    bool hasKeycard3 = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerKeyCards.pickedup == true)
        {
            CollectKeyCard();
        }
    }

    

    public void CollectKeyCard()
    {
        if (PlayerKeyCards.Instance.hasKeycard2) { hasKeycard2 = true; StartCoroutine(KeyCatdFound(hasKeycard2)); }
        if (PlayerKeyCards.Instance.hasKeycard3) { hasKeycard3 = true; StartCoroutine(KeyCatdFound(hasKeycard3)); }
    }

    

    public IEnumerator KeyCatdFound(bool keycard)
    {
        PlayerKeyCards.pickedup = false;
        keycard = false;
        objUI.SetActive(true);
        ObjText.text = "KeyCard Obtained";
        yield return new WaitForSeconds(1f);
        objUI.SetActive(false);
    }
}
