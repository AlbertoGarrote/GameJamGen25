using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    public GeneralEventos Manager;
    private bool heDetectado, Sejecutado;

    private void Start()
    {
        Sejecutado = false;
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento1Lanzados += HacerAccion;
    }
    
    private void HacerAccion(object sender, int i) 
    {
        Manager.realizarEvento();
        Sejecutado = false;
        SoundManager.instance.PlaySound("AVaca", new Vector3(0, 0, 0));
    }
    private void Update()
    {
        heDetectado = Manager.heDetectado();
        if (heDetectado == true && Sejecutado == false)
        {
            Sejecutado = true;
            SoundManager.instance.PlaySound("PVaca", new Vector3(0, 0, 0));
        }
    }
}
