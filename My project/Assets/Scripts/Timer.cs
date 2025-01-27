using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float elapsedTime;
    public int horas, minutos;

    private void Start()
    {
        elapsedTime = 420;
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().BotonPulsado += BotonPulsado;
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        horas = Mathf.FloorToInt(elapsedTime / 60);
        minutos = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", horas, minutos);

        if (horas == 22) 
        {
            Debug.Log("SE ACABÓ");
        }

        if (horas < 7)
        {
            horas = 7;
            minutos = 0;
        }
    }

    private void BotonPulsado(object sender, float tiempoModificar)
    {
        elapsedTime += tiempoModificar;
    }
}
