using UnityEngine;
using TMPro;
using System.Threading;

public class CodeNumber : MonoBehaviour

{
    [SerializeField]
    private TextMeshProUGUI changableNum;
    

    //public int[] nums = new int[9];
    int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNum()
    {
        if (count < 9)
        {
            count++;
            changableNum.text = count.ToString();
        }
        else
        {
            count = 0;
            changableNum.text = count.ToString();
        }
    }

    public void MinusNum() 
    {
        if(count < 9 && count > 0)
        {
            count--;
            changableNum.text = count.ToString();
        }
        else
        {
            count = 0;
            changableNum.text = count.ToString();
        }

    }
}
