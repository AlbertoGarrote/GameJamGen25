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
        GameObject[] listaEventos = GameObject.FindGameObjectsWithTag("evento");

        foreach (GameObject obj in listaEventos) 
        {
            obj.GetComponent<GeneralEventos>().Pillado += Pillado;
        }
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

        if (elapsedTime < 420)
        {
            elapsedTime = 420;
        }
    }

    private void BotonPulsado(object sender, float tiempoModificar)
    {
        elapsedTime += tiempoModificar;
    }
    private void Pillado(object sender, float tiempoModificar)
    {
        elapsedTime -= tiempoModificar;
    }
}
