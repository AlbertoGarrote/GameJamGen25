using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int randomNumber, lastRandom = 0;
    public float intervaloEventos;

    public EventHandler<int> Evento1Lanzados;
    public EventHandler<int> Evento2Lanzados;
    public EventHandler<int> Evento3Lanzados;
    public EventHandler<int> Evento4Lanzados;
    public EventHandler<int> Evento5Lanzados;
    public EventHandler<int> Evento6Lanzados;
    public EventHandler<int> Evento7Lanzados;

    void Start()
    {
        intervaloEventos = 4;
        GameObject timer = GameObject.FindWithTag("Timer");
        Player scriptTimer = timer.GetComponent<Player>();
    }

    void Update()
    {
        randomNumber = UnityEngine.Random.Range(1, 6);

        if (lastRandom == randomNumber) 
        {
            randomNumber++;
        }
        intervaloEventos -= Time.deltaTime;

        if (intervaloEventos < 0)
        {
            intervaloEventos = 4;
            Debug.Log(randomNumber);
            LlamarEvento(randomNumber);
        }
        lastRandom = randomNumber;
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
