using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int randomNumber;
    public int lastRandom = 0;
    public float intervaloEventos;
    public float nivelintervalo1;
    public float nivelintervalo2;
    public float nivelintervalo3;
    private int horaActual;

    private Timer scriptTimer;

    public EventHandler<int> Evento1Lanzados;
    public EventHandler<int> Evento2Lanzados;
    public EventHandler<int> Evento3Lanzados;
    public EventHandler<int> Evento4Lanzados;
    public EventHandler<int> Evento5Lanzados;
    public EventHandler<int> Evento6Lanzados;
    public EventHandler<int> Evento7Lanzados;

    void Start()
    {
        intervaloEventos = 5f;
        nivelintervalo1 = 5f;
        nivelintervalo2 = 3.8f;
        nivelintervalo3 = 3f;
        GameObject timerJuego = GameObject.FindWithTag("Timer");
        scriptTimer = timerJuego.GetComponent<Timer>();
    }

    void Update()
    {
        horaActual = scriptTimer.GetHoras();
        do 
        {
            randomNumber = UnityEngine.Random.Range(1, 8);
        } 
        while (randomNumber == lastRandom);
        
        if (intervaloEventos < 0)
        {
            if (horaActual < 11)
            {
                intervaloEventos = nivelintervalo1;
            }
            else if (horaActual >= 11 &&  horaActual <= 18) 
            {
                intervaloEventos = nivelintervalo2;
            }
            else if (horaActual > 18)
            {
                intervaloEventos = nivelintervalo3;
            }
            lastRandom = randomNumber;
            LlamarEvento(randomNumber);
        }
        else
        {
            intervaloEventos -= Time.deltaTime;
        }
        
    }

    private void LlamarEvento(int i)
    {
        switch (i)
        {
            case 1:
                Evento1Lanzados?.Invoke(this, 1);
                break;
            case 2:
                Evento2Lanzados?.Invoke(this, 1);
                break;
            case 3:
                Evento3Lanzados?.Invoke(this, 1);
                break;
            case 4:
                Evento4Lanzados?.Invoke(this, 1);
                break;
            case 5:
                Evento5Lanzados?.Invoke(this, 1);
                break;
            case 6:
                Evento6Lanzados?.Invoke(this, 1);
                break;
            case 7:
                Evento7Lanzados?.Invoke(this, 1);
                break;
        }
    }
}
