using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event7 : MonoBehaviour
{
    public GeneralEventos Manager;

    private void Start()
    {
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento7Lanzados += HacerAccion;
    }
    
    private void HacerAccion(object sender, int i) 
    {
        Manager.realizarEvento();
    }
}
