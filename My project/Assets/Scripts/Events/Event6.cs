using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event6 : MonoBehaviour
{
    public GeneralEventos Manager;
    private bool heDetectado, Sejecutado;

    private void Start()
    {
        GameObject logic = GameObject.FindWithTag("GameLogic");
        logic.GetComponent<GameLogic>().Evento6Lanzados += HacerAccion;
    }
    
    private void HacerAccion(object sender, int i) 
    {
        Manager.realizarEvento();
        Sejecutado = false;
        SoundManager.instance.PlaySound("AAranya", new Vector3(0, 0, 0));
    }

    private void Update()
    {
        heDetectado = Manager.heDetectado();
        if (heDetectado == true && Sejecutado == false)
        {
            Sejecutado = true;
            SoundManager.instance.PlaySound("PAranya", new Vector3(0, 0, 0));
        }
    }
}
