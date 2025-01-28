using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4 : MonoBehaviour
{
    public GeneralEventos Manager;
    public SpriteManager SpriteManager;

    private void Start()
    {
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento4Lanzados += HacerAccion;
    }
    
    private void HacerAccion(object sender, int i) 
    {
        SpriteManager.AbrirPuerta();
        Manager.realizarEvento();
    }

    private void Update()
    {
        if (Manager.heTerminao() == true) 
        {
            Manager.SetFalse();
            SpriteManager.CerrarPuerta();
        }
    }
}
