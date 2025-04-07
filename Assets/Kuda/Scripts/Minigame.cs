using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    public Slider oxygenSlider;
    public Slider nitrogenSlider;
    public Slider hydrogenSlider;
    public Slider otherElementSlider;
    public Text oxygenText;
    public Text nitrogenText;
    public Text hydrogenText;
    public Text otherElementText;
    public int OxygenValue;
    public int NitrogenValue;
    public int HydrogenValue;
    public int OtherElementValue;
    public Image usedImage;
    public Sprite[] image;
    private bool unlocked = false;
    public GameObject keycard;

    private void Start()
    {
        keycard.SetActive(false);
        unlocked = false;
        SliderPercentage();
        usedImage.overrideSprite = image[0];
}
    private void FixedUpdate()
    {
        ValuestoInt();
        SliderPercentage();
    }
    void ValuestoInt()
    {
        OxygenValue = (int)((oxygenSlider.value / oxygenSlider.maxValue) * 100);
        NitrogenValue = (int)((nitrogenSlider.value / nitrogenSlider.maxValue) * 100);
        HydrogenValue = (int)((hydrogenSlider.value / hydrogenSlider.maxValue) * 100);
        OtherElementValue = (int)((otherElementSlider.value / otherElementSlider.maxValue) * 100);
    }
    void SliderPercentage()
    {
        oxygenText.text = OxygenValue.ToString();
        nitrogenText.text = NitrogenValue.ToString();
        hydrogenText.text = HydrogenValue.ToString();
        otherElementText.text = OtherElementValue.ToString();  
    }

    public void Objective()
    {
        if (OxygenValue == 50 & HydrogenValue == 25 & NitrogenValue == 15 & OtherElementValue == 10)
        {

            unlocked = true;
            usedImage.overrideSprite = image[1];
            keycard.SetActive(true);
        }
        else
        {
            Debug.Log("Thats not what the article says");
            oxygenSlider.value = .5f;
            nitrogenSlider.value = .50f;
            hydrogenSlider.value = .50f;
            otherElementSlider.value = .50f;
        }
    }
}
