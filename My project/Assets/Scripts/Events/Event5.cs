using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event5 : MonoBehaviour
{
    public GeneralEventos Manager;
    private bool heDetectado, Sejecutado;

    private void Start()
    {
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento5Lanzados += HacerAccion;
    }
    
    private void HacerAccion(object sender, int i) 
    {
        Manager.realizarEvento();
        Sejecutado = false;
        SoundManager.instance.PlaySound("At2", new Vector3(0, 0, 0));
    }

    private void Update()
    {
        heDetectado = Manager.heDetectado();
        if (heDetectado == true && Sejecutado == false)
        {
            Sejecutado = true;
            SoundManager.instance.PlaySound("Pt2", new Vector3(0, 0, 0));
        }
    }
}

