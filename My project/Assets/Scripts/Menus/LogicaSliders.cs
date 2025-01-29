using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LogicaSliders : MonoBehaviour
{
    public Slider sliderVolumen;

    private float valorSonido;

    public AudioMixer audioMixer;

    void Start()
    {
        if (PlayerPrefs.HasKey("volumenAudio"))
        {
            LoadValor();
        }
        else
        {
            ChangeVolumenSlider();
        }
    }

    public void ChangeVolumenSlider()
    {
        valorSonido = sliderVolumen.value;
        audioMixer.SetFloat("volumen", Mathf.Log10(valorSonido) * 20);
        PlayerPrefs.SetFloat("volumenAudio", valorSonido);
    }

    private void LoadValor()
    {
        sliderVolumen.value = PlayerPrefs.GetFloat("volumenAudio");
        ChangeVolumenSlider();
    }
}


