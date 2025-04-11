using Unity.Mathematics;
using UnityEngine;

public class PlayerKeyCards : MonoBehaviour
{
    public bool hasKeycard1 = false;
    public bool hasKeycard2 = false;
    public bool hasKeycard3 = false;
  public  static bool pickedup;
    //GameObject other;
    private void Start()
    {
        //other = GameObject.Find("Card");
    }
   /* protected override void Interact()
    {

        if (other.gameObject.CompareTag("Card1"))
        {
         
            hasKeycard1 = true;
            DestroyObject(other.gameObject);
        }
        if (other.gameObject.CompareTag("Card2"))
        {
            hasKeycard2 = true;
            DestroyObject(other.gameObject);
        }
        if (other.gameObject.CompareTag("Card3"))
        {
            hasKeycard3 = true;
            DestroyObject(other.gameObject);
        }
    } */


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Card1"))
        {
              hasKeycard1 = true;
                DestroyObject(other.gameObject);
            
           
        }
        if (other.gameObject.CompareTag("Card2"))
        {
            try { AudioManager.Instance.PlaySound("victorySound"); } catch { }
            hasKeycard2 = true;
                DestroyObject(other.gameObject);
            pickedup = true;
            
          
        }
        if (other.gameObject.CompareTag("Card3"))
        {
            try { AudioManager.Instance.PlaySound("victorySound"); } catch { }
            hasKeycard3 = true;
                DestroyObject(other.gameObject);
            pickedup = true;
            
            
        }
    }


    public static PlayerKeyCards Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

  

}
