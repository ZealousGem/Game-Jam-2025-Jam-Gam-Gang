using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Slider;
    public float Mousesensitivty;
    TMP_Text amount;
    float AudioSound;
    private void Update()
    {
        Slider.onValueChanged.AddListener((v) => {

            Slider.value = v;


        });


    }

    private void Start()
    {
        Mousesensitivty = 100f;
        MouseSensitivity.instance.Amount = Mousesensitivty;
        AudioSound = 1f;

    }

    public void VolumeAudio()
    {
        // AudioManager.instance.SFXVolumeAmount(Slider.value);
        AudioSound = Slider.value;
        AudioManager.Instance.VolumeAmount(AudioSound);
       
    }

    public void MouseSense()
    {

        Mousesensitivty = Slider.value;
        MouseSensitivity.instance.Amount = Mousesensitivty;
        amount = GameObject.FindGameObjectWithTag("Mouse").GetComponent<TMP_Text>();
        int display = (int)Mousesensitivty;
        amount.text = display.ToString();
    }
}