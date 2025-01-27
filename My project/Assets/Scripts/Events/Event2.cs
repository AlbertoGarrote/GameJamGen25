using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    public GeneralEventos Manager;

    private void Start()
    {
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento2Lanzados += HacerAccion;
    }
    
    private void HacerAccion(object sender, int i) 
    {
        Manager.realizarEvento();
    }
}
